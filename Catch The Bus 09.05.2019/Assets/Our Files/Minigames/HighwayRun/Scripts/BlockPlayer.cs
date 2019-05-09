using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    private Vector2 leftSide;
    private Vector2 rightSide;
    private Vector2 startPos;

    void Start()
    {
        startPos = new Vector2(0f, -15f);
        transform.position = startPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Ei päästetä pelaajaa sivuille, mihin kamera ei näe
        leftSide = new Vector2(-13f, transform.position.y);
        rightSide = new Vector2(13f, transform.position.y);


        if (transform.position.x < -13)
        {
            transform.position = leftSide;
        }
        if (transform.position.x > 13)
        {
            transform.position = rightSide;
        }
    }

    

}
