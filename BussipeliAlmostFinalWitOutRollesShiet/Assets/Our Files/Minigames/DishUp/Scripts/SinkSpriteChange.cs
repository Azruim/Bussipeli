using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSpriteChange : MonoBehaviour
{
    public SpriteRenderer sink;
    public Sprite[] sinkSprite;

    public DishRandomizer drScript;
    // Start is called before the first frame update
    void Start()
    {
        sink = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drScript.score == 1)
        {
            sink.sprite = sinkSprite[0];
        }
        if (drScript.score == 2)
        {
            sink.sprite = sinkSprite[1];
        }
        if (drScript.score == 3)
        {
            sink.sprite = sinkSprite[2];

        }
        if (drScript.score == 4)
        {
            sink.sprite = sinkSprite[3];
        }
        if (drScript.score == 5)
        {
            sink.sprite = sinkSprite[4];
        }
        if (drScript.score == 6)
        {
            sink.sprite = sinkSprite[5];
        }
        if (drScript.score == 7)
        {
            sink.sprite = sinkSprite[6];
        }
        if (drScript.score == 8)
        {
            sink.sprite = sinkSprite[7];
        }
        if (drScript.score == 9)
        {
            sink.sprite = sinkSprite[8];
        }
        if (drScript.score == 10)
        {
            sink.sprite = sinkSprite[9];
        }
    }
}
