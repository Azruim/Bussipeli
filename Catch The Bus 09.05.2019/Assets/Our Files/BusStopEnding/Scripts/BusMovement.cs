using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public float moveSpeed;
    private float oldMoveSpeed;

    public GameObject bus;

    public bool busStopping;

    private GameObject[] buses;

    private PlayerBusStop playerBusStop;
    

    // Start is called before the first frame update
    void Start()
    {
        // Laitetaan movespeed talteen, koska se vaihdetaan myöhemmin nollaksi ja tarvitaan sen vahna arvo
        oldMoveSpeed = moveSpeed;
        
        // busseista lista
        buses = GameObject.FindGameObjectsWithTag("Bus");
        playerBusStop = GameObject.Find("Player").GetComponent<PlayerBusStop>();
        //if (buses.Length <= 1)
        //{
        //    // Spawnataan bussi 30 sek välein
        //    InvokeRepeating("SpawnBus", 30, 30);
        //}
        //SpawnBus();

    }

    // Update is called once per frame
    void Update()
    {
        // Bussi liikkuu
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Jos pelaaja on pysäkillä, niin bussi pysähtyy siihen hetkeksi
        if (collision.tag == "Stop" && playerBusStop.atStop == true)
        {
            moveSpeed = 0;
            busStopping = true;
            StartCoroutine(WaitBus());
            
        }

        // Pelaaja bussin kyydissä ja bussi lähtee pysäkiltä
        if (collision.tag == "TheEnd" && playerBusStop.inTheBus == true)
        {
            // Peli ohi
            GameFinished();
            Destroy(gameObject);
            EndingCutscene.curtainMoveDown = true;
        }

        // Jos pelaaja ei ole bussin kyydissä, niin bussi tuhotaan 
        else if (collision.tag == "TheEnd")
        {
            EndingCutscene.curtainMoveDown = true;
            if (buses.Length > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    

    // Bussi odottaa pysäkillä 5 sek ennen kuin jatkaa matkaa
    IEnumerator WaitBus()
    {
        yield return new WaitForSecondsRealtime(5);
        moveSpeed = oldMoveSpeed;
    }

    // Spawnataan bussi
    void SpawnBus()
    {
        Instantiate(bus, new Vector2(64f, 2f), Quaternion.identity);

    }

    // Pääsit bussiin. Peli loppu
    void GameFinished()
    {
        PlayerController.movementOn = true;
        Debug.Log("The End");
    }
}
