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
        if(drScript.score >= 10)
        {
            sink.sprite = sinkSprite[0];
        }
        if (drScript.score >= 20)
        {
            sink.sprite = sinkSprite[1];
        }
    
    }
}
