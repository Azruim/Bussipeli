using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockGameWon : MonoBehaviour
{
    private GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        if (gameStatus.GetSockGameWon())
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    //void Update()
    //{

    //}
        
}
