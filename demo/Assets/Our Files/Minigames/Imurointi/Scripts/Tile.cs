using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] 
    private Material wall, dirty, cleaned, obstacle;
    public int type = 1;

    public void changeType(int num)
    {
        switch(num)
        {
            case 0:
                gameObject.GetComponent<MeshRenderer>().material = wall;
                type = 0;
                break;
            case 1:
                gameObject.GetComponent<MeshRenderer>().material = dirty;
                type = 1;
                break;
            case 2:
                gameObject.GetComponent<MeshRenderer>().material = cleaned;
                type = 2;
                break;
            case 3:
                gameObject.GetComponent<MeshRenderer>().material = obstacle;
                type = 3;
                break;

        }
    }
}
