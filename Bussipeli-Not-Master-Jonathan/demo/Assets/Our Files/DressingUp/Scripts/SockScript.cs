using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockScript : MonoBehaviour
{

    Rigidbody2D sockRB2D;
    public float sockSpeed;
    Vector2 sock;

    public DressingUpScript dressingUp;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        sockRB2D = GetComponent<Rigidbody2D>();
        sock = new Vector2(0, -sockSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dressingUp.gameOver==false)
        transform.Translate(sock);

        if (transform.position.y <= 1.5f || transform.position.y >= 3.5f)
        {
            sock = -sock;
        }

        if(dressingUp.tries <= 0 || dressingUp.gameOver == true)
        {
            //Time.timeScale = 0;
        }

       

       
        
    }
}
