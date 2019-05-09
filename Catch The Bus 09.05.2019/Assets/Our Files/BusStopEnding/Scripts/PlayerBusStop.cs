using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBusStop : MonoBehaviour
{
    public bool atStop;
    public bool inTheBus;
    
    
    public BusMovement bus;

    private Vector3 target;
    private Vector2 startPos;

    void Start()
    {
        // target on bussin takana ja pelaaja liikkuu siihen ennen kuin "hyppää" bussiin (tai siis tehään inactive)
        target = new Vector3(0f, 2.5f, 0f);
        startPos = new Vector2(43f, 3f);
        transform.position = startPos;

        bus = GameObject.Find("Bus").GetComponent<BusMovement>();
    }

    void Update()
    {
        
        // Jos bussi pysähtyy, niin pelaaja liikkuu sen taakse
        if (bus.busStopping == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
            if (transform.position == target)
            {
                // Siirretään kamera pois pelaajasta
                Camera.main.transform.parent = null;
                // Pelaajasta inactive
                gameObject.SetActive(false);
                inTheBus = true;
            }
        }



    }

    // Onko pelaaja pysäkillä
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BusStop")
        {
            atStop = true;
            
        }
       
    }
    // Pelaaja lähtee pysäkiltä
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BusStop")
        {
            atStop = false;
        }
    }
}
