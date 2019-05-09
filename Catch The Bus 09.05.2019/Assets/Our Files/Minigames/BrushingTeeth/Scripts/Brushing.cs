using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Brushing : MonoBehaviour
{
    public float moveSpeed;
    public float upDownSpeed;
    public float timeLeft;

    public Image redScreen;
    public Image clock;

    public GameObject ouch;
    public GameObject blood;
    private GameObject blooddrop;

    private int toothLeft;
    private int gumsTouched = 0;
    public float xLeft;
    public float xRight;
    public float yTop;
    public float yBottom;

    private GameStatus gameStatus;

    private GameObject[] toothList;
    //private GameObject[] bloodList;

    List<GameObject> bloodList = new List<GameObject>();

    Vector3 movePosition = new Vector3(0f, -60f, 0f);

    // Start is called before the first frame update
    void Start()
    {

        // Tehään hampaista lista
        toothList = GameObject.FindGameObjectsWithTag("Tooth");
        toothLeft = toothList.Length;

        // Punainen välähdys opacity nolla ja aktiivinen
        redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0f);
        redScreen.enabled = true;

        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        // Aika joka tikittää alaspäin
        timeLeft -= Time.deltaTime;
        clock.fillAmount = timeLeft * 0.1f;
        if (timeLeft < 0)
        {
            GameOver();
        }

        


    }

    void LateUpdate()
    {
        // Liikkuminen
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }


        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * upDownSpeed * Time.deltaTime, 0f));
        }

        // Estetään harjan liikkuminen alueen ulkopuolelle
        if (transform.position.x < xLeft)
        {
            transform.position = new Vector3(xLeft, transform.position.y, 0f);
        }
        else if (transform.position.x > xRight)
        {
            transform.position = new Vector3(xRight, transform.position.y, 0f);
        }

        if (transform.position.y > yTop)
        {
            transform.position = new Vector3(transform.position.x, yTop, 0f);
        }
        else if (transform.position.y < yBottom)
        {
            transform.position = new Vector3(transform.position.x, yBottom, 0f);
        }

        
        // Veripisarat valuu alaspäin
        
        for(int i = 0; i < bloodList.Count; i++)
        {
            if (bloodList[i] != null && bloodList[i].transform.position != movePosition)
            {
                // Pistetään ne liikkumaan kohti maalia, joka on movepositionissa
                Vector3 newPos = Vector3.MoveTowards(bloodList[i].transform.position, movePosition, 1f * Time.deltaTime);
                bloodList[i].transform.position = newPos;

                // Tehään niistä koko ajan pienempiä
                bloodList[i].GetComponent<Renderer>().transform.localScale -= new Vector3(0.002f, 0.002f, 0);

                // Jos ne on 0 mittasia niin tuhotaan
                if(bloodList[i].GetComponent<Renderer>().transform.localScale.x < 0)
                {
                    Destroy(bloodList[i]);
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Osutaan hammasharjalla hampaan likaan
        if (col.gameObject.tag == "Tooth")
        {
            // Muutetaan läpinäkyväksi ja tuhotaan collider
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            Destroy(col);
            toothLeft -= 1;
            
            

        }

        // Kaikki hampaat harjattu
        if(toothLeft == 0)
        {
            GamePassed();
        }

        // Osutaan ikeneen/huuliin

        if (col.gameObject.tag == "Gum")
        {
            // Väläytetään punaista ruutua nopeasti. Opacity floatia muuttammalla.
            redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0.6f);

            // Luo ja tuhoaa OUCH tekstin
            //Destroy(Instantiate(ouch, col.transform.position, Quaternion.identity), 0.6f);
            if (col.transform.position.x > 5.7)
            {
                Destroy(Instantiate(ouch, new Vector3(5.7f, col.transform.position.y, 0), Quaternion.identity), 0.6f);
            }
            else if (col.transform.position.x < -5.7)
            {
                Destroy(Instantiate(ouch, new Vector3(-5.7f, col.transform.position.y, 0), Quaternion.identity), 0.6f);
            }
            else
            {
                Destroy(Instantiate(ouch, col.transform.position, Quaternion.identity), 0.6f);
            }

            // Luodaan veripisara
            blooddrop = Instantiate(blood, col.transform.position, Quaternion.identity);
            bloodList.Add(blooddrop);

            // Kutsutaan Coroutinea
            StartCoroutine(ExecuteAfterTime(0.3f));

            // Game over kun tarpeeksi moneen ikeneen osuttu
            gumsTouched += 1;
            if(gumsTouched == 5)
            {
                GameOver();
            }
        }
    }

    // Coroutine. Odotetaan hetki ennen kuin punainen ruutu katoaa.
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Vaihdetaan opacity nollaksi
        redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0f);
    }

    // Peli läpi
    void GamePassed()
    {
        Debug.Log("Puhdasta");
        gameStatus.AddPlayerPoints(5);
        SceneManager.LoadScene("main");
    }

    // Game Over
    void GameOver()
    {
        Debug.Log("GAME OVER!");
        SceneManager.LoadScene("main");
    }

}

