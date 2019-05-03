using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DishRandomizer : MonoBehaviour
{
    public bool dishInTheSink;
    public List<GameObject> prefabList = new List<GameObject>();// prefab lista, mistä luodaan altaaseen astiat.

    public bool correctButton;// katsoo, onko oikeaa nappulaa painettu. 
    public int BrushSum;

    //Mukiin liittyviä booleja, tarkastetaan onko nappulat painettu oikeassa järjestyksessä.
    public bool firstMugButton;
    public bool secondMugButton;
    public bool thirdMugButton;
    public bool fourthMugButton;
    public bool wrongMugKey;
    public float aKeyHitTimes, wKeyHitTimes;

    public int score;
    public int spawnedPrefabs;

    public DishBrushMovement dbMovement;// periaatteessa turha, kaiken voi tehdä tässä yhdessä scriptissä.
    public CameraShake camerashake;

    public float waitingTime = 1;// pieni odotusaika, jotta animaatiot kerkee mennä loppuun. Saatetaan poistaa.

    public GameObject fail, succes, gameOver;
    public float textShowTime = 0.5f;

    public int startW, startD, startS, startA; // Mukin ja lautasen muuttujia, joilla tarkastetaan mitä näppäintä on painettu.
    public int mugBrushSum;

    private GameStatus gameStatus;


    void Start()
    {
        dishInTheSink = false;
        BrushSum = 1;

        firstMugButton = false;
        secondMugButton = false;
        thirdMugButton = false;
        fourthMugButton = false;
        wrongMugKey = false;
        mugBrushSum = 1;

        gameStatus = GameObject.Find("GameStatus").GetComponent<GameStatus>();
    }

    void Update()
    {
        waitingTime -= Time.deltaTime;
        textShowTime -= Time.deltaTime;
        if (waitingTime <= 0f)
        {
            waitingTime = 0;
        }

        if(textShowTime <= 0)
        {
            textShowTime = 0;
        }

        if (dishInTheSink == false)
        {
            waitingTime += 0.5f;
            dbMovement.animator.SetBool("Fork", false);
            dbMovement.animator.SetBool("Plate", false);
            dbMovement.animator.SetBool("Mug", false);
            dbMovement.animator.SetBool("Knife", false);
            dbMovement.animator.SetBool("RightButtons", false);
            dbMovement.animator.SetBool("Clean", false);
            int prefabIndex = Random.Range(0, prefabList.Count);
            Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity);
            spawnedPrefabs += 1;

        }
        
        if (GameObject.Find("Fork(Clone)") || GameObject.Find("Spoon(Clone)"))
        {

            dbMovement.animator.SetBool("WrongButtons", false);
            dbMovement.animator.SetBool("Fork", true);


            dishInTheSink = true;
            Debug.Log("haarukka luotiin");

            if (Input.GetKeyUp("w") && textShowTime <= 0 || Input.GetKeyUp("up") && waitingTime <= 0 && textShowTime <= 0)
            {
                
                dbMovement.animator.SetBool("RightButtons", true);
                correctButton = true;
                BrushSum *= 3;

            }

            if (Input.GetKeyUp("s") && textShowTime <= 0 || Input.GetKeyUp("down") && waitingTime <= 0 && textShowTime <= 0)
            {
                dbMovement.animator.SetBool("RightButtons", true);
                BrushSum -= 1;
            }

            if (Input.GetKeyUp("a") && textShowTime <= 0 || Input.GetKeyUp("d") && textShowTime <= 0 || Input.GetKeyUp("left") && textShowTime <= 0 || Input.GetKeyUp("right") && waitingTime <= 0 && textShowTime <= 0)
            {
                dbMovement.animator.SetBool("WrongButtons", true);
                dbMovement.animator.SetBool("RightButtons", false);
                dbMovement.animator.SetBool("Clean", true);
                dishInTheSink = false;
                Destroy(GameObject.Find("Fork(Clone)"));
                Destroy(GameObject.Find("Spoon(Clone)"));
                BrushSum = 1;
                camerashake.shakeDuration = 0.5f;
                fail.SetActive(true);
                textShowTime = 0.5f;
                if (textShowTime <= 0)
                {
                    fail.SetActive(false);
                }

            }
          
        }

        if (GameObject.Find("Knife(Clone)"))
        {

            dbMovement.animator.SetBool("WrongButtons", false);
            dbMovement.animator.SetBool("Knife", true);

            dishInTheSink = true;
            Debug.Log("Veitsi luotiin");

            if (Input.GetKeyUp("a") && textShowTime <= 0 || Input.GetKeyUp("left") && waitingTime <= 0 && textShowTime <= 0)
            {
                dbMovement.animator.SetBool("RightButtons", true);               
                correctButton = true;
                BrushSum *= 3;

            }

            if (Input.GetKeyUp("d") && textShowTime <= 0 || Input.GetKeyUp("right") && waitingTime <= 0 && textShowTime <= 0)
            {
                dbMovement.animator.SetBool("RightButtons", true);
                BrushSum -= 1;
            }

            if (Input.GetKeyUp("w") && textShowTime <= 0 || Input.GetKeyUp("up") && textShowTime <= 0 || Input.GetKeyUp("s") && textShowTime <= 0 || Input.GetKeyUp("down") && waitingTime <= 0 && textShowTime <= 0)
            {
                dbMovement.animator.SetBool("WrongButtons", true);
                dbMovement.animator.SetBool("RightButtons", false);
                dbMovement.animator.SetBool("Clean", true);
                dishInTheSink = false;
                Destroy(GameObject.Find("Knife(Clone)"));
                BrushSum = 1;
                camerashake.shakeDuration = 0.5f;

                fail.SetActive(true);
                textShowTime = 0.5f;
                if (textShowTime <= 0)
                {
                    fail.SetActive(false);
                }

            }

        }

        if (GameObject.Find("Mug(Clone)"))
        {

            dbMovement.animator.SetBool("WrongButtons", false);
            dbMovement.animator.SetBool("Mug", true);

            dishInTheSink = true;
            Debug.Log("Muki luotiin");
            
            
           

            if (Input.GetKeyUp("left") && waitingTime <= 0|| Input.GetKeyUp("a") && waitingTime <= 0) 
                
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;
                aKeyHitTimes++;
                startA += 1;
                mugBrushSum += 2;

            }

            if(Input.GetKeyUp("s") && waitingTime <= 0 || Input.GetKeyUp("down") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;
                aKeyHitTimes++;
                startS += 1;
                mugBrushSum *= 3;
            }

            if (Input.GetKeyUp("d") && waitingTime <= 0 || Input.GetKeyUp("right") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;
                aKeyHitTimes++;
                startD += 1;
                mugBrushSum -= 3;
            }

            if (Input.GetKeyUp("w") && waitingTime <= 0 || Input.GetKeyUp("up") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;
                aKeyHitTimes++;
                startW += 1;
                mugBrushSum *= 2;
            }
            
            

            if(startA >= 2 || startW >= 2 || startD >= 2 || startS >= 2|| startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != 9 ||
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != -1 ||
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != -8 ||
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != 7)

            {
                wrongMugKey = true;
            }

            

            if(startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum ==9 || 
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == -1|| 
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == -8||
                    startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == 7)
            {
                Win();
            }



        }

        if (GameObject.Find("Plate(Clone)"))
        {

            dbMovement.animator.SetBool("WrongButtons", false);
            dbMovement.animator.SetBool("Plate", true);

            dishInTheSink = true;
            Debug.Log("Lautanen luotiin");

            if (Input.GetKeyUp("left") && waitingTime <= 0 || Input.GetKeyUp("a") && waitingTime <= 0)            
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;               
                startA += 1;
                mugBrushSum += 2;

            }

            if (Input.GetKeyUp("s") && waitingTime <= 0 || Input.GetKeyUp("down") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;                
                startS += 1;
                mugBrushSum *= 3;
            }

            if (Input.GetKeyUp("d") && waitingTime <= 0 || Input.GetKeyUp("right") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;              
                startD += 1;
                mugBrushSum -= 3;
            }

            if (Input.GetKeyUp("w") && waitingTime <= 0 || Input.GetKeyUp("up") && waitingTime <= 0)
            {
                firstMugButton = true;
                dbMovement.animator.SetBool("RightButtons", true);
                /*brushTimes -= 1;*/
                correctButton = true;               
                startW += 1;
                mugBrushSum *= 2;
            }



            if (startA >= 2 || startW >= 2 || startD >= 2 || startS >= 2 || startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != -6 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != 9 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != 12 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum != 2 || 
                startA == 1 && startW == 1 && mugBrushSum == 6 )

            {
                wrongMugKey = true;
            }

            if (startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == -6 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == 9 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == 12 ||
                startA == 1 && startW == 1 && startD == 1 && startS == 1 && mugBrushSum == 2)
            {
               Win();
            }

        }
        if (textShowTime <= 0)
        {
            fail.SetActive(false);
            succes.SetActive(false);
        }

        if (spawnedPrefabs >= 11)// kun astioita on luotu 10, peli loppuu.
        {
            Destroy(GameObject.Find("Plate(Clone)"));
            Destroy(GameObject.Find("Fork(Clone)"));
            Destroy(GameObject.Find("Mug(Clone)"));
            Destroy(GameObject.Find("Knife(Clone)"));
            Destroy(GameObject.Find("Spoon(Clone)"));
            if (textShowTime <= 0)
            {
                
                fail.SetActive(false);
                succes.SetActive(false);
                gameOver.SetActive(true);
                camerashake.shakeDuration = 0f;
                dishInTheSink = true;
                gameStatus.AddPlayerPoints(score);
                SceneManager.LoadScene("main");

               
            }
            

        }

        if (score <= 0)
        {
            score = 0;
        }


     Clean();
     Lose();

    }
    void Clean()
    {
        if (BrushSum == 5 || BrushSum == -3)
        {
            Win();
        }

    }

    void Win()// jos pelaaja onnistuu saamaan astian puhtaaksi eli näppäinjärjestys on oikea, voittotilanne.
    {
        dbMovement.animator.SetBool("Clean", true);
        dbMovement.animator.SetBool("RightButtons", false);
        dbMovement.animator.SetBool("Fork", false);
        dbMovement.animator.SetBool("Plate", false);

        dishInTheSink = false;
        Destroy(GameObject.Find("Plate(Clone)"));
        Destroy(GameObject.Find("Fork(Clone)"));
        Destroy(GameObject.Find("Mug(Clone)"));
        Destroy(GameObject.Find("Knife(Clone)"));
        Destroy(GameObject.Find("Spoon(Clone)"));
        Debug.Log("voitit");
        BrushSum = 1;
        succes.SetActive(true);
        textShowTime = 0.5f;

        if (textShowTime <= 0)
        {
            succes.SetActive(false);
        }

        score++;
        
        aKeyHitTimes = 0;
        wKeyHitTimes = 0;

        firstMugButton = false;
        secondMugButton = false;
        thirdMugButton = false;
        fourthMugButton = false;
        wrongMugKey = false;
        startW = 0;
        startD = 0;
        startS = 0;
        startA = 0;
        mugBrushSum = 1;

    }

    void Lose()// jos näppämiä painetaan väärässä järjestyksessä tarpeeksi monta kertaa, häviö.
    {
        if (BrushSum >= 7 || BrushSum <= -2 || wrongMugKey == true)
        {
            dbMovement.animator.SetBool("Clean", true);
            dbMovement.animator.SetBool("RightButtons", false);
            dbMovement.animator.SetBool("WrongButtons", true);
            dbMovement.animator.SetBool("Fork", false);
            dbMovement.animator.SetBool("Plate", false);

            dishInTheSink = false;
            Destroy(GameObject.Find("Plate(Clone)"));
            Destroy(GameObject.Find("Fork(Clone)"));
            Destroy(GameObject.Find("Mug(Clone)"));
            Destroy(GameObject.Find("Knife(Clone)"));
            Destroy(GameObject.Find("Spoon(Clone)"));
            Debug.Log("hävisit");
            BrushSum = 1;
            mugBrushSum = 1;


            camerashake.shakeDuration = 0.5f;
            fail.SetActive(true);
            textShowTime = 0.5f;
            if (textShowTime <= 0)
            {
                fail.SetActive(false);
                
            }

            score--;
            aKeyHitTimes = 0;
            wKeyHitTimes = 0;
            

            firstMugButton = false;
            secondMugButton = false;
            thirdMugButton = false;
            fourthMugButton = false;
            wrongMugKey = false;
            startW = 0;
            startD = 0;
            startS = 0;     
            startA = 0;
        }
    }
}
/*if (aKeyHitTimes >= 2 || wKeyHitTimes >= 2)
{
    wrongMugKey = true;
}

//tarkastetaan painetaanko nappuloita oikeassa järjestyksessä.
if (firstMugButton == true && Input.GetKeyUp("w") && waitingTime <= 0 && textShowTime <= 0 || firstMugButton == true && Input.GetKeyUp("up") && waitingTime <= 0 && textShowTime <= 0)
{
    wKeyHitTimes++;
    secondMugButton = true;


}
if (secondMugButton == true && Input.GetKeyUp("d") && waitingTime <= 0 && textShowTime <= 0 || secondMugButton == true && Input.GetKeyUp("right") && waitingTime <= 0 && textShowTime <= 0)
{
    thirdMugButton = true;
}
if (thirdMugButton == true && Input.GetKeyUp("s") && waitingTime <= 0 && textShowTime <= 0 || thirdMugButton == true && Input.GetKeyUp("down") && waitingTime <= 0 && textShowTime <= 0)
{
    fourthMugButton = true;
}
if (fourthMugButton == true)
{
    Win();
}

//tarkastaa, painetaanko oikeaa nappulaa alussa.
if (firstMugButton == false && Input.GetKeyUp("w") && textShowTime <= 0 || firstMugButton == false && Input.GetKeyUp("up") && textShowTime <= 0 || firstMugButton == false && Input.GetKeyUp("d") && textShowTime <= 0 || firstMugButton == false && Input.GetKeyUp("right") && textShowTime <= 0 || firstMugButton == false && secondMugButton==false && Input.GetKeyUp("s") && waitingTime <= 0 && textShowTime <= 0 || firstMugButton == false && Input.GetKeyUp("down") && waitingTime <= 0 && textShowTime <= 0)
{
    wrongMugKey = true;
    Debug.Log("väärä nappula1");
    camerashake.shakeDuration = 0.5f;
    fail.SetActive(true);
    textShowTime = 0.5f;
    if (textShowTime <= 0)
    {
        fail.SetActive(false);
    }
}
if (secondMugButton == false && Input.GetKeyUp("d")|| secondMugButton == false && Input.GetKeyUp("right") && textShowTime <= 0 || firstMugButton == true && secondMugButton == false && Input.GetKeyUp("s") && textShowTime <= 0 || firstMugButton == true && secondMugButton == false && Input.GetKeyUp("down") && textShowTime <= 0 || secondMugButton == false && Input.GetKeyUp("w") && waitingTime <= 0 && textShowTime <= 0 || secondMugButton == false && Input.GetKeyUp("up") && textShowTime <= 0)

{
    wrongMugKey = true;
    Debug.Log("väärä nappula2");
    camerashake.shakeDuration = 0.5f;
    fail.SetActive(true);
    textShowTime = 0.5f;
    if (textShowTime <= 0)
    {
        fail.SetActive(false);
    }
}
if (thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("d") && textShowTime <= 0 || (thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("right") && textShowTime <= 0 || thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("s") && textShowTime <= 0 || thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("down") && textShowTime <= 0 || thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("a") && waitingTime <= 0 && textShowTime <= 0 || thirdMugButton == false && secondMugButton == true && Input.GetKeyUp("left") && waitingTime <= 0) && textShowTime <= 0)
{
    wrongMugKey = true;
    Debug.Log("väärä nappula3");
    camerashake.shakeDuration = 0.5f;
    fail.SetActive(true);
    textShowTime = 0.5f;
    if(textShowTime <= 0)
    {
        fail.SetActive(false);
    }
}*/
