using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cars : MonoBehaviour
{
    public float moveSpeed;
    private float speedMultiplier;
    private bool turned;
    

    private Vector2 spawnPos;
    private Vector3 movedPos;
    private Vector3 movedPosDown;
    private Vector2 movement;
    
    public GameObject pixelcar;

    private GameObject player;
    private GameStatus gameStatus;
    private int hitMax;

    // Start is called before the first frame update
    void Start()
    {
        turned = false;


        // Autojen speed multiplier
        speedMultiplier = 1.7f;

        player = GameObject.Find("Player");
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        hitMax = 5;

        // Tähän if lauseeseen, jos on jotain itemeitä mitkä hidastaa autojen vauhtia.

        if (gameStatus.GetItemStatus("banana"))
        {
            speedMultiplier = 1f;
        }
    }

    
       
    void LateUpdate()
    {

        // Autojen liikkuminen
        transform.Translate(Vector3.right * moveSpeed * speedMultiplier * Time.deltaTime);

        // Käännetään auto kun tietyssä kohdassa
        if (transform.position.x < -17 && !turned)
        {
            transform.Rotate(0, 0, 180);
            turned = true;
        }
        else if (transform.position.x > 17 && !turned)
        {
            transform.Rotate(0, 0, 180);
            turned = true;
        }
        else
        {
            turned = false;
        }
    }

    // Collision pelaajan kanssa
    // GAME OVER
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("hit meh");
            gameStatus.AddCarHitCount();
            //Debug.Log(gameStatus.GetCarHitCount());
            if (gameStatus.GetCarHitCount() >= hitMax)
            {
                Debug.Log("Game Over!");
                gameStatus.SetPlayerPassedHighway(false);
                gameStatus.SetEnteredChangeAreaStatus(true);
                gameStatus.SetPlayerPosition(new Vector3(43.0f, 3.0f, 0.0f));
                SceneManager.LoadScene("BusStop");
            } else
            {
                player.transform.position = new Vector3(0.0f, -15.0f, 0.0f);
            }
            
            //Time.timeScale = 0;
        }
    }

    

    
}
