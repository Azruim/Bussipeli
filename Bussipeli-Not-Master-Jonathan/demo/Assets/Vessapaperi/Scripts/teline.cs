using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teline : MonoBehaviour
{
    public Sprite telineEhja;
    public Sprite telineRikki;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = telineEhja;
    }

    public void spritevaihto()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = telineRikki;
    }
}
