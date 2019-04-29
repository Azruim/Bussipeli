using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleCheckScript : MonoBehaviour
{

    private float timer;
    private float maxTime;
    private bool gameEnd;

    private GameStatus gameStatus;

    public DressingUpScript dressUpScript;
     // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        //timer = 0.0f;
        //maxTime = 2.0f;
        gameEnd = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            //Debug.Log(Time.deltaTime);
            //timer += Time.deltaTime;
            //if (timer >= maxTime)
            //{
                Debug.Log("game ended");

                SceneManager.LoadScene("main");
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        /*if (collision.gameObject.tag == "Edge")
        {
            dressUpScript.tries -= 1;
            Debug.Log("GameOver");
            
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            Debug.Log("Sukka jalassa");
            gameStatus.AddPlayerPoints(5);
            //Time.timeScale = 0;
            dressUpScript.gameOver = true;
            gameEnd = true;
        }
    }
}
