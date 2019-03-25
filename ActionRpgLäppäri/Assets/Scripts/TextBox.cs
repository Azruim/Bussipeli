using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public Text interaction;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        interaction.gameObject.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().triggered)
        {
            interaction.gameObject.SetActive(true);
            interaction.text = "poppo";
        }
    }
}
