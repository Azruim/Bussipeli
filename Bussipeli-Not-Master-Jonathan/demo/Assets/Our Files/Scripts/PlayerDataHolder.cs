using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHolder : MonoBehaviour
{
    private Vector3 playerPosition;
    private bool sockGamePlayed;

    static PlayerDataHolder trueOne;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("started");
        if(trueOne != null)
        {
            Destroy(this.gameObject);
            return;
        }
        trueOne = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        playerPosition = new Vector3(-4.5f, -1.9f, 0.0f);
        sockGamePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sockGamePlayed);

    }

    public void SetPlayerPosition(Vector3 newPosition)
    {
        playerPosition = newPosition;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public void SetSockGamePlayed(bool setter)
    {
        sockGamePlayed = setter;
    }

    public bool GetSockGamePlayed()
    {
        return sockGamePlayed;
    }
}
