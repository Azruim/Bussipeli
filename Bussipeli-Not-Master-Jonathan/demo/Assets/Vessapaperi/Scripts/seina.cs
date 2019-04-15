using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seina : MonoBehaviour
{
    public GameObject paperiFail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "vessapaperi_TP")
        {
            Debug.Log("asd");
            collision.gameObject.GetComponentInChildren<paperiFail>().seinaHavio();
        }
    }

}
