using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperiFail : MonoBehaviour
{
    public float xThrow = -4.0f;
    public float yThrow = 11.0f;
    public int gravityAfter = 3;
    public GameObject telineobjekti;
    public float endTime;
    private float startTime;
    private bool theEnd; //onko peli häviötilassa

    void Start()
    {
        theEnd = false;
        startTime = 0;
    }

    void Update()
    {
        if (theEnd) {
            //häviöcooldown (minipeli päättyy x ajan päästä häviöehdon täyttymisestä)
            startTime += Time.deltaTime;
            if (startTime > endTime)
            {
                this.gameover();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //häviö paperin osuessa telineeseen
        if (collision.gameObject.tag == "teline_osuma")
        {
            if (transform.parent.gameObject.GetComponent<vessapaperi>().winning != true)
            {
                theEnd = true;
                loppuheitto(); //paperin lentofysiikka häviötilanteessa
                telineobjekti.gameObject.GetComponent<teline>().spritevaihto(); //telinesprite muuttuu rikkinäiseksi telineeksi
            }
        }
    }

    //häviö osuessa takaseinään
    public void seinaHavio()
    {
        theEnd = true;
        loppuheitto();
        gameover();
    }

    private void loppuheitto() {
        transform.parent.gameObject.GetComponent<vessapaperi>().notFail = false;
        transform.parent.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityAfter;
        Vector2 paperthrow = new Vector2(xThrow, yThrow);
        transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(paperthrow, ForceMode2D.Impulse);
    }

    private void gameover()
    {
        Debug.Log("fail");
        theEnd = false;
    }
}
