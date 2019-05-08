using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashClothes : MonoBehaviour
{
    private GameStatus gameStatus;
    private bool isInTrigger;
    public SpriteRenderer pesukoneAuki;
    public Sprite pesukoneKiinni;
    private bool[] shirts;

    // Start is called before the first frame update
    void Start()
    {
        isInTrigger = false;
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        if(gameStatus.GetWashingMachineStatus())
        {
            pesukoneAuki.sprite = pesukoneKiinni;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInTrigger && !gameStatus.GetWashingMachineStatus())
        {
            shirts = gameStatus.GetShirtHolder();
            Debug.Log(shirts[0] + " eka");
            Debug.Log(shirts[1] + " toka");
            Debug.Log(shirts[2] + " kolmas");
            pesukoneAuki.sprite = pesukoneKiinni;
            gameStatus.SetWashingMashineStatus(true);
            gameStatus.SetPlayerHoldsObjectStatus(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInTrigger = false;
        }
    }
}
