using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitStore : MonoBehaviour
{
    private GameStatus gameStatus;
    //// Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
        gameStatus.SetTimerOn(false);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void ExitFromStore()
    {
        //Debug.Log("Button pressed");
        gameStatus.SetTimerOn(true);
        SceneManager.LoadScene("main");
    }
}
