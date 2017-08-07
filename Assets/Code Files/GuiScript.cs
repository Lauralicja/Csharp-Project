using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiScript : MonoBehaviour {

  
    public Button NewGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Button();
	}

  
    void Button()
    {
        Button button = NewGame.GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = "New Game";
        button.onClick.AddListener(StartGame);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Tetris");
        Border.points = 0;
    }


}
