using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    private SpriteRenderer fridgeSpriteRenderer;
    [SerializeField]
    private Sprite fridgeMad;
    [SerializeField]
    private Sprite fridgeNormal;


    private GameObject mainCamera;
    private Vector3 cameraTarget;
    private Vector3 playerTarget;
    public float speed;
    private GameStatus gameStatus;

    private DialogueTrigger dialogueTrigger;
    private GameObject player;

    private bool cameraStoppedMoving;

    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.Find("Main Camera");
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        player = GameObject.Find("Player");
        fridgeSpriteRenderer = GameObject.Find("HouseHolder").transform.Find("jaakaappi").gameObject.GetComponent<SpriteRenderer>();

        cameraStoppedMoving = false;

        dialogueTrigger = this.GetComponent<DialogueTrigger>();
        //mainCamera.transform.position = new Vector3(-33.0f, 34.0f, -50.0f);
        if(gameStatus.GetGameStartedFirstTime())
        {
            cameraTarget = new Vector3(-31.0f, 34.0f, -40.0f);
            gameStatus.SetTimerOn(false);
            PlayerController.movementOn = false;

            playerTarget = new Vector3(-50.0f, 4.0f, 1.0f);

            PlayerController.cutsceneOn = true;
        } else
        {
            Debug.Log("rip me");
            GameObject.Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus.GetGameStartedFirstTime())
        {

            if (mainCamera.transform.position == cameraTarget)
            {
                //PlayerController.movementOn = false;
                //dialogueTrigger.TriggerDialogue();
                fridgeSpriteRenderer.sprite = fridgeMad;
                if (dialogueTrigger != null)
                {
                    
                    dialogueTrigger.TriggerDialogue();
                    dialogueTrigger = null;
                }
                if (DialogueManager.dialogueEnded)
                {
                    fridgeSpriteRenderer.sprite = fridgeNormal;
                    PlayerController.movementOn = false;
                    cameraTarget = new Vector3(0.0f, 0.0f, -100.0f);
                    
                    if(mainCamera.transform.position == cameraTarget)
                    {
                        cameraStoppedMoving = true;
                        PlayerController.movingY = 1.0f;
                        PlayerController.playerCutsceneMoving = true;
                        
                        //player.GetComponent<PlayerController>().playerMoving = true;
                        
                        //gameStatus.SetGameStartedFirstTime(false);
                        //SceneManager.LoadScene("MiniGame");
                        if (player.transform.position == playerTarget)
                        {
                            
                            playerTarget = new Vector3(-59.0f, 4.0f, -1.0f);
                            PlayerController.movingX = -1.0f;
                            if (player.transform.position == playerTarget)
                            {
                                gameStatus.SetGameStartedFirstTime(false);
                                //player.GetComponent<PlayerController>().playerMoving = false;
                                PlayerController.playerCutsceneMoving = false;
                                PlayerController.cutsceneOn = false;
                                PlayerController.movementOn = true;
                                PlayerController.movingY = 0.0f;
                                PlayerController.movingX = 0.0f;
                                gameStatus.SetMiniGamePlayed("sockGame", true);
                                SceneManager.LoadScene("MiniGame");
                            }
                        }
                        
                    }
                }
            }
        }

    }
    private void FixedUpdate()
    {
        if(gameStatus.GetGameStartedFirstTime())
        {
            MoveCamera();
        }

        if(gameStatus.GetGameStartedFirstTime() && cameraStoppedMoving)
        {
            MovePlayer();
        }
        
    }

    private void MoveCamera()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraTarget, speed*Time.deltaTime);
    }
    private void MovePlayer()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerTarget, 50.0f * Time.deltaTime);
    }
}
