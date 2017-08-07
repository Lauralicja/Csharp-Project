using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScore : MonoBehaviour {

    public Text scoreText;
 

    private static int score;
	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        PrintScore();
    }
 
     
    
    public void PrintScore()
    {
        score = Border.points;
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

    }


}
