using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClothes : MonoBehaviour
{
    private bool isInTrigger;
    [SerializeField]
    private int shirtNumber;
    private GameStatus gameStatus;
    private bool[] shirts;

    // Start is called before the first frame update
    void Start()
    {
        isInTrigger = false;
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        shirts = gameStatus.GetShirtHolder();
        if(shirts[shirtNumber])
        {
            GameObject.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInTrigger && !gameStatus.GetWashingMachineStatus())
        {
            gameStatus.SetPlayerHoldsObjectStatus(true);
            gameStatus.SetShirtHolder(true, shirtNumber);
            GameObject.Destroy(gameObject);
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
        if(collision.gameObject.tag == "Player")
        {
            isInTrigger = false;
        }
    }
}
