using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    //dialogiteksti muuttuja
    public Text dialogueText;
    //jono dialogin sivuille
    private Queue<string> sentences;
    public Animator animator;
    public Button yesBtn;
    public Button noBtn;
    public bool question;
    private bool stopInput, buttons = false;
    private string scene;

    private GameStatus gameStatus;

    void Start()
    {
        sentences = new Queue<string>();
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        stopInput = false;

        yesBtn.onClick.AddListener(ChangeScene);
        noBtn.onClick.AddListener(EndDialogue);
    }

    void Update()
    {
        //Dialogi controlli sivujen vaihtoon
        if (Input.GetKeyDown("space") && !PlayerController.movementOn && !stopInput)
        {
            DisplayNextSentence();
        }


    }

    private void LateUpdate()
    {
        if (buttons)
        {
            yesBtn.gameObject.SetActive(true);
            noBtn.gameObject.SetActive(true);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        scene = dialogue.scene;
        gameStatus.SetTimerOn(false);
        //tuo dialogi boksin esiin
        animator.SetBool("isOpen", true);
        sentences.Clear();
        question = dialogue.question;

        //lisätään sivut jonoon
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //näytetään ensimmäinen sivu
        DisplayNextSentence();
    }

    //uuden sivun lataus ja näyttäminen
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (question)
            {
                stopInput = true;
                buttons = true;
                return;
            }
            else
            {
                EndDialogue();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //kirjoitus efekti
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        PlayerController.movementOn = true;
        buttons = false;
        yesBtn.gameObject.SetActive(false);
        noBtn.gameObject.SetActive(false);
        stopInput = false;
        gameStatus.SetTimerOn(true);
        question = false;
    }

    void ChangeScene()
    {
        EndDialogue();
        SceneManager.LoadScene(scene);  
    }
}
