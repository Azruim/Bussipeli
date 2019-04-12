using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressingUpScript : MonoBehaviour
{

    public float footSpeed;
    public float upForce;
    Vector2 lastPosition = Vector2.zero;
    Vector2 speed;
    Vector2 position;
    public float sensitivity;

    Rigidbody2D footRB2D;
    public float tries;

    public bool gameOver;
    public bool keyUp;

    public Transform sock;

    public float footXOffset;
    public float footYOffset;

    public float sockYOffset;
    public float sockXOffset;

    public float movement;
    

    // Start is called before the first frame update
    void Start()
    {
        keyUp = true;
        gameOver = false;
        
        footRB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = 0;
        if (Input.GetKeyDown("w") && transform.position.y < 3.5f && gameOver == false)
        {
            //footRB2D.AddForce(transform.up * upForce, ForceMode2D.Impulse);
            position.y = transform.position.y;
            position.y += 2;
            position.x = transform.position.x;
            transform.position = position;

        }
        if (Input.GetKeyDown("d"))
        {
            movement = 1;
        }
        if (Input.GetKeyDown("a"))
        {
            movement = -1;
        }
        //if(transform.position.y >= sock.transform.position.y - sockYOffset 
        //    && transform.position.x + footYOffset >=sock.transform.position.x -sockXOffset
        //    || transform.position.y >= sock.transform.position.y - sockYOffset
        //    && transform.position.x - footYOffset <= sock.transform.position.x + sockXOffset)
        //{

            /*if (transform.position.y + footYOffset >= sock.transform.position.y - sockYOffset)
            {
                if (transform.position.x + footXOffset >= sock.transform.position.x - sockXOffset 
                    && transform.position.x - footXOffset <= sock.transform.position.x + sockXOffset
                    ||
                    transform.position.x - footXOffset >= sock.transform.position.x + sockXOffset 
                    && transform.position.x + footXOffset <= sock.transform.position.x - sockXOffset)


                /*if(transform.position.x + footYOffset > -sockXOffset || transform.position.x + footYOffset < sockXOffset)
                {
                    transform.position = new Vector2(transform.position.x, sock.transform.position.y - sockYOffset - footYOffset);

                }
            }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x < 1.5f || transform.position.x > -1.5f)
        {
            sensitivity = 2;
        }

        else
        {
            sensitivity = 1;
        }

        if(transform.position.y > -5.5f )
        {
            transform.Translate(new Vector2(0f, -0.05f));
        }

        
        
       
        
            footRB2D.AddForce(transform.right * Random.Range(10f, 5f) * sensitivity * movement);
            /*playerMoving = true;*/
            /*lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);*/
        

        
        
            

        



    


        if(transform.position.x < -6.5f)
        {
            footRB2D.velocity = new Vector3(0f, footRB2D.velocity.y, 0f);
            transform.position = new Vector2(-6.5f, transform.position.y);
        }
        if(transform.position.x > 6.5f)
        {
            footRB2D.velocity = new Vector3(0f, footRB2D.velocity.y, 0f);
            transform.position = new Vector2(6.5f, transform.position.y);
        }
        if (tries <= 0)
        {
            Debug.Log("MiniGame is completely over, no socks for you");           
            Time.timeScale = 0;
            gameOver = true;
            
        }

        





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "InnerEdgeRight" && gameOver == false)
        {
            tries -= 1;
            transform.position = new Vector2(collision.gameObject.transform.position.x + 1f, transform.position.y);
            Debug.Log("siirrettiin jalkaa");
        }
        if (collision.gameObject.tag == "InnerEdgeLeft" && gameOver==false)
        {
            tries -= 1;
            transform.position = new Vector2(collision.gameObject.transform.position.x - 1f, transform.position.y);
            Debug.Log("siirrettiin jalkaa");
        }
    }




}
