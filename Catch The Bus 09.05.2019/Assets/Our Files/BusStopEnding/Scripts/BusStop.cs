using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    public GameObject player;
    

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 4f)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = 6000;
        }
        else
        {
            gameObject.GetComponent<Renderer>().sortingOrder = 2;
        }
    }
}
