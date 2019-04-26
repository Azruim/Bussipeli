using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float movespeed, boostMultiplier;
    [SerializeField]
    private int endTime;
    private float currentMovespeed, startTime;
    private Vector3 direction, oldDirection;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentMovespeed = movespeed;
        oldDirection = direction;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            direction.x = -1;
            direction.y = 0;
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            direction.x = 1;
            direction.y = 0;
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            direction.y = -1;
            direction.x = 0;
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            direction.y = 1;
            direction.x = 0;
        }
        if (Input.GetKey("space"))
            currentMovespeed = movespeed * boostMultiplier;
        else
            currentMovespeed = movespeed;


        var tmp = (direction - oldDirection).normalized; //lasketaan liikkeen suunta


        //kohdistetaan pelaaja oikein aikaisemman suunnan mukaan
        if (tmp.x < 0)
        {
            transform.position = new Vector3(Mathf.CeilToInt(transform.position.x), transform.position.y, transform.position.z);
        }
        if (tmp.x > 0)
        {
            transform.position = new Vector3(Mathf.FloorToInt(transform.position.x), transform.position.y, transform.position.z);
        }
        if (tmp.y < 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.CeilToInt(transform.position.y), transform.position.z);
        }
        if (tmp.y > 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.FloorToInt(transform.position.y), transform.position.z);
        }

        transform.Translate(direction * currentMovespeed * Time.deltaTime);
        oldDirection = direction;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Tile")
        {
            switch (col.gameObject.GetComponent<Tile>().type) {

                case 0:
                    Debug.Log("Hit wall, game over!");
                    GameEnd();
                    break;
                case 1:
                    col.gameObject.GetComponent<Tile>().changeType(2);
                    score++;
                    break;
                case 2:
                    Debug.Log("Hit cleaned, game over!");
                    GameEnd();
                    break;
                case 3:
                    Debug.Log("Hit obstacle, game over!"); 
                    GameEnd();
                    break;

            }
        }
    }

    void GameEnd()
    {
        movespeed = 0;
        Debug.Log("Pisteet: " + score);
        StartCoroutine(wait(endTime));

    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("main");
    }
}
