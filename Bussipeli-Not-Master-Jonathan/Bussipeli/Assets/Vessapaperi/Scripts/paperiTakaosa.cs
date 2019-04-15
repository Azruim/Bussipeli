using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperiTakaosa : MonoBehaviour
{
    public int winDropGravity = 3; //painovoima jolla vessapaperi tippuu telineeseen voiton jälkeen

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "teline_osuma")
        {
            Debug.Log("voitto");
            transform.parent.gameObject.GetComponent<vessapaperi>().winning = true;
            transform.parent.gameObject.GetComponent<Rigidbody2D>().gravityScale = winDropGravity;
        }
    }

}
