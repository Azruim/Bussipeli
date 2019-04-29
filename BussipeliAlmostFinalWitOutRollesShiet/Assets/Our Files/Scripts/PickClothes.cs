using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClothes : MonoBehaviour
{
    public bool playerPicking;

    // Start is called before the first frame update
    void Start()
    {
        playerPicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerPicking)
        {
            Object.Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPicking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerPicking = false;
        }
    }
}
