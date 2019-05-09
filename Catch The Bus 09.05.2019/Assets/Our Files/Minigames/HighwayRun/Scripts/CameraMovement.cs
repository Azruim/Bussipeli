using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    private Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        // Kamera seuraa pelaajaa vain y-akselilla
        transform.position = newPos;
        newPos.y = player.transform.position.y + 2f;
        newPos.x = 0;
        newPos.z = -10;
    }
}
