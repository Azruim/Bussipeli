using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //SINGLETON:
    //"Singleton" variable. Used to make sure we always have only one GameStatus and to know which we want to exist at all times.
    static GameStatus trueOne;

    //PLAYER INFO:
    //Vector3 used to know the players position and to also set it.
    private Vector3 playerPosition;

    //MINIGAMES:
    //Booleans for minigames, so that GameStatus knows if they've been played. Also used to stop the player from replaying those games.
    private bool sockGamePlayed;
    private bool toiletPaperGamePlayed;

    //TIMER:
    //Variables for our clock timer
    private int minTime;
    private int secTime;
    //Boolean that is used to freeze our timer when wanted.
    private bool timerOn;
    //Used to count 1 second.
    private float oneSecondCheck;


    // Start is called before the first frame update
    void Awake()
    {
        //SINGLETON & DON'T DESTROY ON LOAD:
        //Used to check if the GameStatus is the one we want to exist.
        if (trueOne != null)
        {
            Destroy(this.gameObject);
            return;
        }
        trueOne = this; //We set our GameStatus as the one we want to exist.
        GameObject.DontDestroyOnLoad(this.gameObject); //We tell Unity that we don't want this GameObject to be destroyed.

        //PLAYER INFO:
        playerPosition = new Vector3(-4.5f, -1.9f, 0.0f); //We set the starting coordinates for our player character, when the game starts.
        
        //MINIGAMES:
        //We set minigames to be NOT played by default at the start of the game.
        sockGamePlayed = false;
        toiletPaperGamePlayed = false;


        //TIMER:
        //We set our countdown time variables to be 2 minutes by default.
        minTime = 2;
        secTime = 0;
        //We set timerOn, so that the countdown moves by default.
        timerOn = true;
        //We set our second counter to start from 0.
        oneSecondCheck = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sockGamePlayed);

        //TIMER:
        if(timerOn) //If true, our timer moves.
        {
            MoveTime(); //Calls for our timer and makes it move.
        }
        

    }
    //PLAYER INFO:
    //Used to GET players position, so that when we switch scene back to the overworld, we can put the players to the last position they were on.
    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }
    //Used to SET players position, so that when we switch scenes, we can save the players position.
    public void SetPlayerPosition(Vector3 newPosition)
    {
        playerPosition = newPosition;
    }
   
    //MINIGAMES:
    //Used to GET a specific boolean for a minigame.
    public bool GetMiniGamePlayed(string miniGameName)
    {
        if(miniGameName == "sockGame")
        {
            return sockGamePlayed;
        } else if (miniGameName == "toiletPaperGame")
        {
            return toiletPaperGamePlayed;
        }
        return true;
    }
    //Used to SET a specific boolean for a minigame.
    public void SetMiniGamePlayed(string miniGameName, bool setter)
    {
        if (miniGameName == "sockGame")
        {
            sockGamePlayed = setter;
        } else if (miniGameName == "toiletPaperGame")
        {
            toiletPaperGamePlayed = setter;
        }
    }

    //TIMER:
    //Moves the timer "forward".
    private void MoveTime()
    {
        oneSecondCheck += Time.deltaTime; //We count a second.

        if ((int)oneSecondCheck == 1) //If 1 second has passed, we execute and add 1 second to our countdown timer.
        {
            oneSecondCheck = 0.0f;
            secTime -= 1;
            if (secTime == -1) //If seconds go lower than 0, we execute and set seconds to 59 and decrease minutes by 1.
            {
                secTime = 59;
                minTime -= 1;
            }
        }
        Debug.Log(minTime + ":" + secTime); //Used to check that time flows correctly through console.
    }
    
    public int GetSeconds() //GETs the timer seconds.
    {
        return secTime;
    }
    public void SetSeconds(int setter) //SETs the timer seconds.
    {
        secTime = setter;
    }
    public int GetMinutes() //GETs the timer minutes.
    {
        return minTime;
    }
    public void SetMinutes(int setter) //SETs the timer minutes.
    {
        minTime = setter;
    }

    public bool GetTimerOn() //GETs the boolean for timerOn, which is used to freeze the time by changing it to "false".
    {
        return timerOn;
    }
    public void SetTimerOn(bool setter) //SETs the boolean for timerOn, which is used to freeze the time by changing it to "false".
    {
        timerOn = setter;
    }


}
