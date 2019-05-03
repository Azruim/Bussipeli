using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    //public float timer;
    //public GameObject timerAnnounce;
    //public Text timerText;



    ////public float val = 33.789876f;

    ////private TimerScript timerrr;

    //private int minTime;
    //private int secTime;

    //[HideInInspector]
    //public bool timerOn;

    ////static TimerScript trueOne;

    ////used to make sure a second is a consistent "1" second.
    //private float oneSecondCheck;

    //void Awake()
    //{
    //    //Used to check if the GameStatus is the one we want to exist .
    //    if (trueOne != null)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    trueOne = this; //We set our GameStatus as the one we want to exist.
    //    GameObject.DontDestroyOnLoad(this.gameObject); //We tell Unity that we don't want this GameObject to be destroyed.
    //}                                                  

    //Variable to hold our GameStatus.
    private GameStatus timer;

    // Start is called before the first frame update
    void Start()
    {
        //minTime = 2;
        //secTime = 0;
        //timerOn = true;
        //timerAnnounce.SetActive(false);

        //timer.SetSeconds(30);
        //timer.SetMinutes(1);

        //Gets the GameStatus component, so we can use its methods.
        timer = GameObject.Find("GameStatus").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {

        
        //This is used to display our countdown timer properly, with two numbers always being shown at all times (example: 10:04).
        if (timer.GetSeconds() < 10 && timer.GetMinutes() > 10)
        {
            //Debug.Log(timer.GetMinutes() + ":" + "0" + timer.GetSeconds());
            //timerText.text = minTime + ":" + "0" + secTime;
            gameObject.GetComponent<Text>().text = timer.GetMinutes() + ":" + "0" + timer.GetSeconds();
        }
        else if (timer.GetSeconds() < 10 && timer.GetMinutes() < 10)
        {
            //Debug.Log("0" + timer.GetMinutes() + ":" + "0" + timer.GetSeconds());
            //timerText.text = "0" + minTime + ":" + "0" + secTime;
            gameObject.GetComponent<Text>().text = "0" + timer.GetMinutes() + ":" + "0" + timer.GetSeconds();
        }
        else if (timer.GetSeconds() > 10 && timer.GetMinutes() < 10)
        {
            //Debug.Log("0" + timer.GetMinutes() + ":" + timer.GetSeconds());
            //timerText.text = "0" + minTime + ":" + secTime;
            gameObject.GetComponent<Text>().text = "0" + timer.GetMinutes() + ":" + timer.GetSeconds();
        }
        else
        {
            //Debug.Log(timer.GetMinutes() + ":" + timer.GetSeconds());
            //timerText.text = minTime + ":" + secTime;
            gameObject.GetComponent<Text>().text = timer.GetMinutes() + ":" + timer.GetSeconds();
        }

        //Debug.Log(System.Math.Round(val, 2));
        //if(timerOn)
        //{
        //    MoveTime();
        //}

        //timer -= Time.deltaTime;
        //val -= Time.deltaTime;
        ////Debug.Log(System.Math.Round(val));

        //if (timer <= 10f)
        //{

        //    timerAnnounce.SetActive(true);

        //}
        //if (timer <= 5f)
        //{

        //    timerAnnounce.SetActive(false);

        //}

        //if (timer <= 0f)
        //{
        //    timer = 20f;
        //    Debug.Log("Time is up");
        //    PlayerController.movementOn = false;
        //}
    }

    //void MoveTime()
    //{
    //    //secTime = 67.9987659f;

    //    //tester = (int)secTime;

    //    //Debug.Log(tester);

    //    //System.Math.Round(secTime += Time.deltaTime);
    //    oneSecondCheck += Time.deltaTime;
    //    //Debug.Log(secTime % 60.0f);
    //    if ((int)oneSecondCheck == 1)
    //    {
    //        oneSecondCheck = 0.0f;
    //        secTime -= 1;
    //        if(secTime == -1)
    //        {
    //            secTime = 59;
    //            minTime -= 1;
    //        }
    //    }

    //    if (secTime < 10 && minTime > 10)
    //    {
    //        Debug.Log(minTime + ":" + "0" + secTime);
    //        timerText.text = minTime + ":" + "0" + secTime;
    //        //gameObject.GetComponent<Text>().text = minTime + ":" + "0" + secTime;
    //    }
    //    else if (secTime < 10 && minTime < 10)
    //    {
    //        Debug.Log("0" + minTime + ":" + "0" + secTime);
    //        timerText.text = "0" + minTime + ":" + "0" + secTime;
    //        //gameObject.GetComponent<Text>().text = "0" + minTime + ":" + "0" + secTime;
    //    }
    //    else if (secTime > 10 && minTime < 10)
    //    {
    //        Debug.Log("0" + minTime + ":" + secTime);
    //        timerText.text = "0" + minTime + ":" + secTime;
    //        //gameObject.GetComponent<Text>().text = "0" + minTime + ":" + secTime;
    //    }
    //    else
    //    {
    //        Debug.Log(minTime + ":" + secTime);
    //        timerText.text = minTime + ":" + secTime;
    //        //gameObject.GetComponent<Text>().text = minTime + ":" + secTime;
    //    }

    //}




}
