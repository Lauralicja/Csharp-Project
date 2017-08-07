using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiHighScore : MonoBehaviour {

    public Text HighScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PrintHighScore();
	}
    public void PrintHighScore()
    {

        HighScore = GetComponent<Text>();
        HighScore.text = "1st highest score: " + Game.stHighScore.ToString() +
                         "\n2nd highest score: " + Game.ndHighScore.ToString() +
                         "\n3rd highest score: " + Game.rdHighScore.ToString();
    }

}
