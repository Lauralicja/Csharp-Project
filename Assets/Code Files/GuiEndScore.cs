using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiEndScore : MonoBehaviour {

    public Text scoreEndText;

    // Use this for initialization
    void Start () {
        PrintEndingScore();
    }
	
	// Update is called once per frame
	void Update () {
       
	}


    public void PrintEndingScore()
    {

        scoreEndText.text = "Congratulations! Your final score was: " + Border.points.ToString();
       
    }


}
