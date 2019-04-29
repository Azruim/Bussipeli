using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seina : MonoBehaviour
{
    public GameObject paperiFail;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "vessapaperi_TP")
        {
            Debug.Log("asd");
            collision.gameObject.GetComponentInChildren<paperiFail>().seinaHavio();
        }
    }

}
