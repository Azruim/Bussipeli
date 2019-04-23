using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vessapaperi : MonoBehaviour
{
    private float directionY;
    Vector2 movement;
    private Rigidbody2D rb2d;
    public float yNopeus = 1;
    public float xNopeus = 1;
    public float endTime;
    private float startTime;
    private bool theVoitto;
    private bool notMoving; //pysäyttää ohjauksen voiton jälkeen

    [HideInInspector]
    public bool notFail;
    public bool winning;

    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        notFail = true;
        winning = false;
        theVoitto = false;
        notMoving = false;
        startTime = 0;
    }

    void Update()
    {

        if (theVoitto)
        {
                this.voitto();
        }

        //ohjaus
        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            directionY = 1.0f;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5)
        {
            directionY = -1.0f;
        }

        movement = new Vector2(1.0f * xNopeus, directionY * yNopeus);
        
    }

    private void FixedUpdate()
    {
        //ehdot pelaajan kontrolloimalle liikkumiselle
        if (notFail && !winning && !notMoving)
        {
            MoveCharacter(movement);
        }
        else if (winning) {
            theVoitto = true;
        }
    }

    void MoveCharacter (Vector2 direction)
    {
        rb2d.velocity = new Vector2(1.0f, direction.y);
    }

    private void voitto()
    {
        //voittocooldown (minipeli päättyy x ajan päästä voittoehdon täyttymisestä)
        startTime += Time.deltaTime;
        if (startTime > endTime)
        {
            Debug.Log("voitit jes");
            SceneManager.LoadScene("main");
            theVoitto = false;
            winning = false;
            notMoving = true;
        }
    }
}