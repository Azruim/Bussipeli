using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //dialogiteksti muuttuja
    public Text dialogueText;
    //jono dialogin sivuille
    private Queue<string> sentences;
    public Animator animator;

    private GameStatus timer;

    void Start()
    {
        sentences = new Queue<string>();

        timer = GameObject.Find("GameStatus").GetComponent<GameStatus>();
    }

    void Update()
    {
        //Dialogi controlli sivujen vaihtoon
        if (Input.GetKeyDown("space") && !PlayerController.movementOn)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        timer.SetTimerOn(false);
        //tuo dialogi boksin esiin
        animator.SetBool("isOpen", true);
        sentences.Clear();

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
            EndDialogue();
            //Debug.Log("dialogi ended");
            timer.SetTimerOn(true);
            return;
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
        //Debug.Log("Dialogue ended!");
        animator.SetBool("isOpen", false);
        PlayerController.movementOn = true;
    }

}
