using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    private bool playerInTrigger;
    public string miniGameScene;

    // Start is called before the first frame update
    void Start()
    {

        playerInTrigger = false;
        //GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInTrigger)
        {
            SceneManager.LoadScene(miniGameScene);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
