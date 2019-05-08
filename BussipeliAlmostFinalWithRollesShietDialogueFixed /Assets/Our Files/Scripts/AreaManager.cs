using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaManager : MonoBehaviour
{
    public string otherArea;
    private GameStatus gameStatus;
    [SerializeField]
    private Vector3 areaSpawnCoordinates;
    void Start()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameStatus.SetEnteredChangeAreaStatus(true);
            gameStatus.SetPlayerPosition(areaSpawnCoordinates);
            SceneManager.LoadScene(otherArea);
        }
    }
}
