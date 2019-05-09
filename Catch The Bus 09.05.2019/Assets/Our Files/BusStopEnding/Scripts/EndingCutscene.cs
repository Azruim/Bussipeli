using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{

    private GameObject bus;
    private GameObject player;
    private GameObject curtain;
    private GameStatus gameStatus;

    private Vector3 playerTarget;
    private Vector3 curtainTarget;
    private bool playerStop;
    public static bool curtainMoveDown;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.movementOn = false;
        PlayerController.cutsceneOn = true;
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        player = GameObject.Find("Player");
        bus = GameObject.Find("Bus");
        curtain = GameObject.Find("Curtain");
        playerTarget = new Vector3(1.0f, 2.7f, 0.0f);
        curtainTarget = new Vector3(-9.0f, 18.0f, 0.0f);
        playerStop = false;
        if(gameStatus.GetPlayerPassedHighway())
        {
            bus.transform.position = new Vector3(65.0f, 2.0f, 0.0f);
        } else
        {
            bus.transform.position = new Vector3(50.0f, 2.0f, 0.0f);
        }       
        curtainMoveDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerStop)
        {
            PlayerController.movingX = -1.0f;
            PlayerController.playerCutsceneMoving = true;
        }
        if(player.transform.position == playerTarget)
        {
            playerStop = true;
            PlayerController.playerCutsceneMoving = false;
            PlayerController.cutsceneOn = false;
            playerStop = true;
            //PlayerController.movementOn = true;
            PlayerController.movingX = 0.0f;
        }
        if(/*curtain.transform.position == curtainTarget && */Input.GetKey(KeyCode.R))
        {
            PlayerController.playerCutsceneMoving = false;
            PlayerController.cutsceneOn = false;
            playerStop = true;
            //PlayerController.movementOn = true;
            PlayerController.movingX = 0.0f;
            PlayerController.movingY = 0.0f;
            Destroy(GameObject.Find("GameStatus"));
            SceneManager.LoadScene("main");
        }
    }

    private void FixedUpdate()
    {
        if(!playerStop)
        {
            MovePlayer();
        }
        
        if(curtainMoveDown)
        {
            MoveCurtain();
        }
    }

    private void MovePlayer()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerTarget, 5.0f * Time.deltaTime);
    }

    private void MoveCurtain()
    {
        curtain.transform.position = Vector3.MoveTowards(curtain.transform.position, curtainTarget, 10.0f * Time.deltaTime);
    }
}
