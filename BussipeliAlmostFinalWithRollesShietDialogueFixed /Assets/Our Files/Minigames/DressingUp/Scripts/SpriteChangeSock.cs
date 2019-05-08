using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeSock : MonoBehaviour
{
    public SpriteRenderer sock;
    public Sprite[] sockSprite;

    public HoleCheckScript hCScript;
    // Start is called before the first frame update
    void Start()
    {
        sock = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hCScript.gameEnd == true)
        {
            sock.sprite = sockSprite[0]; 
        }

    }
}
