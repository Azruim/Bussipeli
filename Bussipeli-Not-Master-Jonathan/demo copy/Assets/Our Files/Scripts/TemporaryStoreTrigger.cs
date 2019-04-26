using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporaryStoreTrigger : MonoBehaviour
{

    private bool playerInTrigger;
    // Start is called before the first frame update
    void Start()
    {
        playerInTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("FridgeStore");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}
