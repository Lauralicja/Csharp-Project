using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiExit : MonoBehaviour
{


    public Button Exit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Button();
    }


    void Button()
    {
        Button button = Exit.GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = "Exit";
        button.onClick.AddListener(ExitGame);

    }
    public void ExitGame()
    {
        Application.Quit();
        
    }


}
