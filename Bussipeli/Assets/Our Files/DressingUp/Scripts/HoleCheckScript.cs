using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCheckScript : MonoBehaviour
{
    public DressingUpScript dressUpScript;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        /*if (collision.gameObject.tag == "Edge")
        {
            dressUpScript.tries -= 1;
            Debug.Log("GameOver");
            
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            Debug.Log("Sukka jalassa");
            Time.timeScale = 0;
            dressUpScript.gameOver = true;
        }
    }
}
