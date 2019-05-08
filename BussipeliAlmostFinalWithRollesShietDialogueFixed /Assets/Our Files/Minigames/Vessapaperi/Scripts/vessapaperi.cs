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
    public float boost;
    private float boostMultiplier = 1;
    private float startTime;
    private bool theVoitto;
    private bool notMoving; //pysäyttää ohjauksen voiton jälkeen

    [HideInInspector]
    public bool notFail;
    public bool winning;

    private GameStatus gameStatus;

    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        notFail = true;
        winning = false;
        theVoitto = false;
        notMoving = false;
        startTime = 0;

        transform.position = new Vector2(-4.5f, (Random.Range(0, 5) - 2));

        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
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

        //välilyöntiboosti (nopeuskerroin muokattavissa unitysta vessapaperin "boost"-parametrilla)
        if (Input.GetButton("Jump"))
        {
            boostMultiplier = boost;
        }
        else {
            boostMultiplier = 1;
        }

        movement = new Vector2(1.0f * (xNopeus * boostMultiplier), directionY * (yNopeus * boostMultiplier));
        //Debug.Log(xNopeus * boostMultiplier);
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
        rb2d.velocity = new Vector2(direction.x, direction.y);
    }

    private void voitto()
    {
        //voittocooldown (minipeli päättyy x ajan päästä voittoehdon täyttymisestä)
        startTime += Time.deltaTime;
        if (startTime > endTime)
        {
            Debug.Log("voitit jes");
            theVoitto = false;
            winning = false;
            notMoving = true;
            gameStatus.AddPlayerPoints(5);
            SceneManager.LoadScene("main");
        }
    }
}