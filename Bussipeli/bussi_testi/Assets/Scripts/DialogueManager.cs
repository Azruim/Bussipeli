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

    void Start()
    {
        sentences = new Queue<string>();
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
        Debug.Log("Dialogue ended!");
        animator.SetBool("isOpen", false);
        PlayerController.movementOn = true;
    }

}
