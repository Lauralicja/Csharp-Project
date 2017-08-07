using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static int stHighScore;
    public static int ndHighScore;
    public static int rdHighScore;
    // Use this for initialization
    void Start() {
        stHighScore = PlayerPrefs.GetInt("stHighScore");
        ndHighScore = PlayerPrefs.GetInt("ndHighScore");
        rdHighScore = PlayerPrefs.GetInt("rdHighScore");
    }

    // Update is called once per frame
    void Update() {
      
    }


    public string typeOfBlock()
    {
        int whichType = Random.Range(1, 8);
        string typeName = "Blocks/Block_L";
        switch (whichType)
        {
            case 1:
                typeName = "Blocks/Block_L";
                break;
            case 2:
                typeName = "Blocks/Block_J";
                break;
            case 3:
                typeName = "Blocks/Block_S";
                break;
            case 4:
                typeName = "Blocks/Block_Z";
                break;
            case 5:
                typeName = "Blocks/Block_Sq";
                break;
            case 6:
                typeName = "Blocks/Block_I";
                break;
            case 7:
                typeName = "Blocks/Block_T";
                break;

        }
        return typeName;
    }



    public void spawnBlocks()
    {
        int width = Border.borderWidth;
        int height = Border.borderHeight;
        Vector2 randomPlace = new Vector2(Random.Range(3, width-1), height);
        GameObject newBlock = Resources.Load(typeOfBlock()) as GameObject;
        Instantiate(newBlock, randomPlace, Quaternion.identity);

    }

    public void SaveScore()
    {
        if (Border.points > stHighScore)
        {
            PlayerPrefs.SetInt("rdHighScore", ndHighScore);
            PlayerPrefs.SetInt("ndHighScore", stHighScore);
            PlayerPrefs.SetInt("stHighScore", Border.points);
        }
        else if (Border.points < stHighScore && Border.points > ndHighScore)
        {
            PlayerPrefs.SetInt("rdHighScore", ndHighScore);
            PlayerPrefs.SetInt("ndHighScore", Border.points);
        }
        else if (Border.points < ndHighScore && Border.points > rdHighScore)
        {
            PlayerPrefs.SetInt("rdHighScore", Border.points);
        }
        else { }
    }

    public void GameOver()
    {
        SaveScore();
        SceneManager.LoadScene("GameOver");
      
    }
    

}
