using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    private bool playerInTrigger;
    public string miniGameScene;

    [SerializeField]
    private string miniGameName; //name of the minigame, used to info GameStatus, which minigame related info we want to access

    //variable that will hold GameStatus component
    private GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        //player is set to be outside of trigger by default
        playerInTrigger = false;
        //Gets GameStatus component 
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInTrigger)
        {
            if(!gameStatus.GetMiniGamePlayed(miniGameName)) //gets the boolean for the minigame by sending the name as string, so that GameStatus what minigame we are 
            {
                gameStatus.SetMiniGamePlayed(miniGameName, true); //sets the minigame as "played", by sending a string so that GameStatus knows what minigame is we want to set as true
                SceneManager.LoadScene(miniGameScene);
            }
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}
