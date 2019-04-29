using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBed : MonoBehaviour
{

    public bool makingBed;
    public SpriteRenderer sanky;
    public Sprite sankyPedattu;

    // Start is called before the first frame update
    void Start()
    {
        makingBed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && makingBed)
        {
            sanky.sprite = sankyPedattu;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            makingBed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            makingBed = false;
        }
    }
}
