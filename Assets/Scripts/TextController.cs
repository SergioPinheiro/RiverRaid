using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private Text text;
    private GameObject button;
    private GameObject quitbutton;


    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        button = GameObject.Find("Restart Button");
        quitbutton = GameObject.Find("Quit Button");
        //Debug.Log(button);
    }
	
	// Update is called once per frame
	void Update () {
        text.text = PlaneController.text;
        if (text.text == "")
        {
            button.active = false;
            quitbutton.active = false;
        }
        else
        {
            button.active = true;
            quitbutton.active = true;
        }
            

    }
}
