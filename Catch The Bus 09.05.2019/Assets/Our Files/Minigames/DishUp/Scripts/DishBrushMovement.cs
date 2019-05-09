using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishBrushMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed;

    public bool movingHorizontal;
    public bool movingVertical;

    public Animator animator;

    public int[] plate;
    public int startInt;

    public DishRandomizer dr;


    // Start is called before the first frame update
    void Start()
    {
        movingHorizontal = false;
        movingVertical = false;
        rb2d = GetComponent<Rigidbody2D>();
        //plateScript = gameObject.GetComponent<PlateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(dr.correctButton == true)
        {
            animator.SetBool("RightButtons", true);
            animator.SetBool("Brushing", true);
            animator.SetBool("Clean", false);
        }
        if(dr.dishInTheSink == false)
        {
            dr.correctButton = false;
            animator.SetBool("Clean", true);
            animator.SetBool("RightButtons", false);
            animator.SetBool("Brushing", false);
        }*/
    }

    /*void Plate()
    {
        while 
        startInt = GetDirection();
        for(int i = 0; i<5; i++)
        {
            if(plate[i] == startInt)
            {
                startInt = i;
                break;
            }
        }*/
    

    /*public int GetDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            return 0;
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            return 1;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            return 2;
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            return 3;
        }

        else
        {
            return 4;
        }

    }*/
}

