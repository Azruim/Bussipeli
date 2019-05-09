using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public static bool cutsceneOn;
    [HideInInspector]
    public static float movingY;
    [HideInInspector]
    public static float movingX;
    [HideInInspector]
    public static bool playerCutsceneMoving;
    //public static Vector2 lastmoving;

    //Player animation related variables
    public Animator anim;
    public bool playerMoving;
    public Vector2 lastMove;
    private GameObject dialogue;

    public bool isInTrigger;
    public bool triggered;

    //Reseting game varables
    private bool resetGame;
    private float resetCounterTime;
    private float timeItTakesToReset = 3.0f;
    private string beginningLevel = "main";


    //Movement variables
    public float speed = 1.0f;
    private Rigidbody2D rb2d;
    public Vector2 movement;

    //Used to freeze players controls
    public static bool movementOn = true;

    private Collider2D sideCollider;
    private Collider2D frontCollider;

    //Vector3 that used just incase of problems
    private Vector3 checkVector;
    //variable for GameStatus component
    private GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //gets box collider 2d from child SideCollision
        sideCollider = transform.Find("SideCollision").gameObject.GetComponent<BoxCollider2D>();
        //gets Players Box collider 2D
        frontCollider = GetComponent<BoxCollider2D>();
        //Disables players other collider 
        frontCollider.enabled = false;

        //Vector with 0.0f in all axis, used to that the player will start in the right position
        checkVector = new Vector3(0.0f,0.0f,0.0f);
        //Gets the gamestatus component
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        
        //Debug.Log(gameStatus.GetPlayerPosition());
        //if the GameStatus, for whatever reason, hasn't set a coordinates for playerpostion, this is used as a failsafe
        if(gameStatus.GetPlayerPosition() == checkVector)
        {
            this.transform.position = new Vector3(-4.5f, -1.9f, 0.0f);
        }
        this.transform.position = gameStatus.GetPlayerPosition();

        gameStatus.SetEnteredChangeAreaStatus(false); //When the player is "created" in a new scene, it sets the enteredChangeArea back to false.

    }

    // Update is called once per frame
    void Update()
    {
        triggered = false;
        playerMoving = false;

        //Player movement on/off checker
        if (movementOn)
        {
            //Players movement Input
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            //Players Animator inputs 
            if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                playerMoving = true;
                sideCollider.enabled = true;
                frontCollider.enabled = false;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            } else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                playerMoving = true;
                sideCollider.enabled = false;
                frontCollider.enabled = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            //Player Space button input
            if (Input.GetKeyUp("space") && isInTrigger && !gameStatus.GetPlayerHoldsObjectStatus())
            {
                triggered = true;
                if (dialogue != null)
                {
                    movementOn = false;
                    dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                    dialogue = null;
                }
                //Debug.Log("Triggered!!");
            }
        } else
        {
            movement = new Vector2(0.0f, 0.0f); //Makes sure that when we feeze the players controls, that they stop moving and won't slide around.
        }
        
        //Animator guidelines

        if(cutsceneOn)
        {
            anim.SetFloat("MoveX", movingX);
            anim.SetFloat("MoveY", movingY);
            anim.SetBool("PlayerMoving", playerCutsceneMoving);
            //anim.SetFloat("LastMoveX", lastmoving.x);
            //anim.SetFloat("LastMoveY", lastmoving.y);
        } else
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }


        //Resetting game by pressing R-button for 3 seconds
        if (Input.GetKey(KeyCode.R))
        {
            resetCounterTime += Time.deltaTime;
            if (resetCounterTime >= timeItTakesToReset)
            {
                resetGame = true;
            }
        }
        else
        {
            resetCounterTime = 0.0f;
            resetGame = false;
        }
        if (resetGame)
        {
            PlayerController.playerCutsceneMoving = false;
            PlayerController.cutsceneOn = false;
            //PlayerController.movementOn = true;
            PlayerController.movingX = 0.0f;
            PlayerController.movingY = 0.0f;
            Destroy(GameObject.Find("GameStatus"));
            SceneManager.LoadScene(beginningLevel);
        }
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    //Player Movement method
    void MoveCharacter(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            isInTrigger = true;
            dialogue = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            isInTrigger = false;

        }
    }

    private void OnDestroy()
    {
        //Debug.Log("I was destroyed");
        if(!gameStatus.GetEnteredChangeAreaStatus()) //If player did NOT enter a ChangeAreaTrigger, then we save it's last coordinates.
        {
            gameStatus.SetPlayerPosition(this.transform.position); //When the player gets destroyed, we send the players coordinates to the GameStatus.
        }
    
    }
}
    

