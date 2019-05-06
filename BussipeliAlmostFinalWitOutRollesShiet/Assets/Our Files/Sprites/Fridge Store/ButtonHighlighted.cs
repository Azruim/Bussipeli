using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlighted : MonoBehaviour, ISelectHandler, IDeselectHandler //IPointerEnterHandler, 
{
    //Variables for the child image/text GameObjects.
    private GameObject cursorImage;
    private GameObject soldSignImage;
    private GameObject priceText;

    [SerializeField]
    private int price; //Item price
    [SerializeField]
    private string itemName; //Item name, used to inform GameStatus regarding our items status.

    private GameStatus gameStatus; //Holds our GameStatus

    // Start is called before the first frame update
    void Start()
    {
        //Gets our GameStatus to use its item status and player point currency.
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        cursorImage = transform.GetChild(0).gameObject; //Gets the child image GameObject Cursor.
        cursorImage.SetActive(false); //We set Cursor to be "hidden" by default when our button/item isn't highlighted.
        soldSignImage = transform.GetChild(1).gameObject; //Gets the child image GameObject Sold_Sign.
        priceText = transform.GetChild(2).gameObject; //Gets the child text GameObject Price.
        priceText.GetComponent<Text>().text = price + "p";
        PlayerController.movementOn = false;
        
        //If our player doesn't have this item, we set Sold_Sign image "hidden", but if they have we set our Price text to be "hidden".
        if (!gameStatus.GetItemStatus(itemName))
        {
            soldSignImage.SetActive(false);
        } else
        {
            priceText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsHighlighted() == true)
        //{
        //    //Output that the GameObject was highlighted, or do something else
        //    Debug.Log("Selectable is Highlighted");
        //}
        //Debug.Log(gameStatus.GetPlayerPoints());
    }

    //Used when highlighting buttons with a mouse, not needed, but here just in case fr now...
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    //do your stuff when highlighted
    //    //Debug.Log("PointerEnter Works!");
    //}

    //When we highlight our button/item with keyboard/controller, things happen.
    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log("Select works!");
        cursorImage.SetActive(true); //When item/button is highlighted we "activate" our Cursor to show up.
    }
    //When we unhighlight our button/item with keyboard/controller, things happen.
    public void OnDeselect(BaseEventData data)
    {
        //Debug.Log("Deselected");
        cursorImage.SetActive(false); //When item/button is unhighlighted we "hide" our Cursor.
    }

    //Method that is run when a item is pressed.
    public void BuyItem()
    {
        //If the players points are equal or higher than price AND player doesn't have this item, execute.
        if (gameStatus.GetPlayerPoints() >= price && !gameStatus.GetItemStatus(itemName))
        {
            gameStatus.MinusPlayerPoints(price); //We decrease players points by price amount.
            soldSignImage.SetActive(true); //We set our Sold_Sign image active.
            priceText.SetActive(false); //We set our Price text as "hidden", when bought.
            //We update GameStatus so that it knows player now has this specific item, by sending the items name to it.
            gameStatus.SetItemStatus(itemName, true);
            transform.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        //else
        //    Debug.Log("Not enough points/Or already bought");
    }

}
