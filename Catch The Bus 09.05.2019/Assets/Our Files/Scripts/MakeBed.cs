using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBed : MonoBehaviour
{

    public bool isInTrigger;
    public SpriteRenderer sanky;
    public Sprite sankyPedattu;

    private GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        isInTrigger = false;

        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>(); 

        if(gameStatus.GetBedMadeStatus())
        {
            sanky.sprite = sankyPedattu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInTrigger && !gameStatus.GetBedMadeStatus() && !gameStatus.GetPlayerHoldsObjectStatus())
        {
            sanky.sprite = sankyPedattu;
            gameStatus.SetBedMadeStatus(true);
            gameStatus.AddPlayerPoints(2);
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
