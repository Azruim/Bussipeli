using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public float timer;
    public GameObject timerAnnounce;
    // Start is called before the first frame update
    void Start()
    {
        timerAnnounce.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
      
        
        if (timer <= 10f)
        {
            
            timerAnnounce.SetActive(true);
            
        }
        if (timer <= 5f)
        {

            timerAnnounce.SetActive(false);
            
        }

        if (timer <= 0f)
        {
            timer = 20f;
            Debug.Log("Time is up");
            PlayerController.movementOn = false;
        }
    }

    
    
        
    
}
