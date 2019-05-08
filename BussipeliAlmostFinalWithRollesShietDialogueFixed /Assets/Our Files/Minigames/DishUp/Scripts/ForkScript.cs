using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkScript : MonoBehaviour
{
    public float brushTimes;

    public DishBrushMovement dbMovement;
    public DishRandomizer dr;

    public bool correctButton;

    //public int brushDirUp;
    //public int brushDirDown;

    public int correctBrushSum;
    // Start is called before the first frame update
    void Start()
    {
        
        correctBrushSum = 1;
        correctButton = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            /*brushTimes -= 1;*/
            correctButton = true;
            correctBrushSum *= 3;

        }

        if (Input.GetKeyUp("d"))
        {
            correctBrushSum -= 1;
        }

        if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
        {
            Destroy(gameObject);
        }
        Clean();
    }

    void Clean()
    {
        if (correctBrushSum == 5)
        {
            Destroy(gameObject);
            Debug.Log("voitit");
        }

    }
}