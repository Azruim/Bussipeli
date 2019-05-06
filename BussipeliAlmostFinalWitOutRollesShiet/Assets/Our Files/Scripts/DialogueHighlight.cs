using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueHighlight : MonoBehaviour, ISelectHandler, IDeselectHandler //IPointerEnterHandler, 
{
    //Variables for the child image/text GameObjects.
    private GameObject cursorImage;

    // Start is called before the first frame update
    void Start()
    {
        cursorImage = transform.GetChild(0).gameObject; //Gets the child image GameObject Cursor.
        cursorImage.SetActive(false); //We set Cursor to be "hidden" by default when our button/item isn't highlighted.

    }

    // Update is called once per frame
    void Update()
    {
       
    }

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
}

