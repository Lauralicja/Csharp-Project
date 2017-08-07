using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
   
    public static int points = 0;
    int howMuchRows = 0;
    public static int borderWidth = 11;
    public static int borderHeight = 21;
    public static Transform[,] borderArea = new Transform[borderWidth,borderHeight];
    
    void Start()
    {
        FindObjectOfType<Game>().spawnBlocks();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public Vector2 roundedBorders(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public bool IsInBorders(Vector2 pos)
    {
        return ((int)pos.x > 1 && (int)pos.x < borderWidth && (int)pos.y >= 1);
    }
    public bool IsOver(Vector2 pos)
    {
        return ((int)pos.y > borderHeight+1);
    }

 
    public Transform AssignBlockToPlace(Vector2 pos)
    {
        if (pos.y > borderHeight-1)
            return null;
        else
            return borderArea[(int)pos.x, (int)pos.y];
    }

    public void IsInArea(Blocks block)
    {
      for(int x=0; x<borderWidth; ++x)
        {
            for(int y=0; y<borderHeight; ++y)
            {
                if (borderArea[x, y] != null) {
                    if (borderArea[x, y].parent == block.transform)
                        borderArea[x, y] = null;
                }   
            }
        }
        foreach (Transform blockxy in block.transform)
        {
            Vector2 pos = roundedBorders(blockxy.position);
            if(pos.y < borderHeight)
              borderArea[(int)pos.x, (int)pos.y] = blockxy;
        }
    }

    public bool IsRowFull(int y)
    {
        for(int x=2; x<borderWidth; ++x)
        {
            if (borderArea[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteThis(int y)
    {
        for (int x = 2; x < borderWidth; ++x)
        {
            Destroy(borderArea[x, y].gameObject);
            borderArea[x, y] = null;
        }

    }
    public void MoveThat(int y)
    {

        for (int i = y; i < borderHeight; ++i)
        {
            for (int x = 0; x < borderWidth; ++x)
            {
                if (borderArea[x, i] != null)
                {
                    borderArea[x, i - 1] = borderArea[x, i];
                    borderArea[x, i] = null;
                    borderArea[x, i - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }


    public void DeleteAndMove()
    {
        for (int y = 0; y < borderHeight; ++y)
        {
            if (IsRowFull(y) == true)
            {
               DeleteThis(y);
                MoveThat(y+1);
                --y;
                howMuchRows++;
               
            }
        }
        if (howMuchRows == 0) { }
        else if (howMuchRows == 1) { points += 100; }
        else if (howMuchRows == 2) { points += 250; }
        else if (howMuchRows == 3) { points += 375; }
        else if (howMuchRows == 4) { points += 500; }
        else { points += 1000; }
        howMuchRows = 0;

    }




}
