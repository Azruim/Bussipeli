using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerPoints : MonoBehaviour
{
    public Text playerPointsText;
    private GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerPointsText = gameObject.GetComponent<Text>();
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = "Points: " + gameStatus.GetPlayerPoints();
    }
}
