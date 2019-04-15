using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player animation related variables
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
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
    //private GameObject 



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
            if (Input.GetKeyUp("space") && isInTrigger)
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
        }
        
        //Animator guidelines
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

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
    }
}
    

