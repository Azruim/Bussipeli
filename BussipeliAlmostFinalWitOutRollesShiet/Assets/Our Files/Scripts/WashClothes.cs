using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashClothes : MonoBehaviour
{

    public bool playerWashing;
    public SpriteRenderer pesukoneAuki;
    public Sprite pesukoneKiinni;

    // Start is called before the first frame update
    void Start()
    {
        playerWashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerWashing)
        {
            pesukoneAuki.sprite = pesukoneKiinni;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWashing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWashing = false;
        }
    }
}
