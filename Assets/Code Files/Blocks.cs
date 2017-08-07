using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    float fall = 0;
    float fallingSpeed = 1;
    public bool canRotate = true;
  

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
        Falling();
        Keys();
      
	}
    void TimeToSpeedConverter()
    {
        if (Time.timeSinceLevelLoad <= 10) fallingSpeed = 1;
        else if (Time.timeSinceLevelLoad > 10 && Time.timeSinceLevelLoad <= 20) fallingSpeed = 0.9f;
        else if (Time.timeSinceLevelLoad > 20 && Time.timeSinceLevelLoad <= 40) fallingSpeed = 0.8f;
        else if (Time.timeSinceLevelLoad > 40 && Time.timeSinceLevelLoad <= 60) fallingSpeed = 0.7f;
        else if (Time.timeSinceLevelLoad > 60 && Time.timeSinceLevelLoad <= 80) fallingSpeed = 0.6f;
        else if (Time.timeSinceLevelLoad > 80 && Time.timeSinceLevelLoad <= 100) fallingSpeed = 0.5f;
        else if (Time.timeSinceLevelLoad > 100 && Time.timeSinceLevelLoad <= 130) fallingSpeed = 0.4f;
        else fallingSpeed = 0.3f;
    }

    void Falling()
    {

        TimeToSpeedConverter();

        if (Time.time - fall >= fallingSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
            if (inRightPlace() == false)
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<Border>().DeleteAndMove();
                enabled = false;
                FindObjectOfType<Game>().spawnBlocks();               
            }
            else FindObjectOfType<Border>().IsInArea(this);
            if (Lose() == true)
            {
                FindObjectOfType<Game>().GameOver();
            }
           
           
            
        }
       
    }



    void Keys() {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (inRightPlace() == false)
                transform.position += new Vector3(1, 0, 0);
            else FindObjectOfType<Border>().IsInArea(this);

        }


        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (canRotate == true && transform.rotation.eulerAngles.z >= 90)
                transform.Rotate(0, 0, -90);

            else
                transform.Rotate(0, 0, 90);

            if (inRightPlace() == false)
            {
                if (canRotate == true)
                {
                    if(transform.rotation.eulerAngles.z >= 90)
                    transform.Rotate(0, 0, -90);
                    else
                        transform.Rotate(0, 0, 90);
                }
                else
                    transform.Rotate(0, 0, -90);
            }
            else FindObjectOfType<Border>().IsInArea(this);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (inRightPlace() == false)
            {
                transform.position += new Vector3(0, 1, 0);
            }
            else FindObjectOfType<Border>().IsInArea(this);

        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (inRightPlace() == false)
                transform.position += new Vector3(-1, 0, 0);
            else FindObjectOfType<Border>().IsInArea(this);
        }

    }

   
    bool inRightPlace()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = FindObjectOfType<Border>().roundedBorders (block.position);
          

            if (FindObjectOfType<Border>().IsInBorders (pos) == false)
               
            {
                return false;
            }
            if (FindObjectOfType<Border>().AssignBlockToPlace(pos) != null && FindObjectOfType<Border>().AssignBlockToPlace(pos).parent != transform)
            {
                return false;
            }

        }
        return true;
    }



    bool Lose()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = FindObjectOfType<Border>().roundedBorders(block.position);

            if (FindObjectOfType<Border>().IsOver(pos) == true)

            {
                return true;
            }
        
        }
        return false;
    }


}
