using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public float brushTimes;
    public DishBrushMovement dbMovement;
    public bool correctButton;

    //public int brushDirUp;
    //public int brushDirDown;

    public int correctBrushSum;
    // Start is called before the first frame update
    void Start()
    {
        correctBrushSum = 1;
        correctButton = false;
        dbMovement = GetComponent<DishBrushMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("w"))
        {
            /*brushTimes -= 1;*/
            correctButton = true;
            correctBrushSum *= 3;

        }

        if (Input.GetKeyUp("s"))
        {
            correctBrushSum -= 1;
        }

        if(Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            Destroy(gameObject);
        }
        CleanPlate();
    }

    void CleanPlate()
    {
        if (correctBrushSum == 5)
        {
            Destroy(gameObject);
            Debug.Log("voitit");
        }
             
    }

    /*void BreakDish()
    {
        if(correctBrushSum <=-2 || correctBrushSum >= )
    }*/


}
