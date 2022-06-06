using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private static GridManager Instance;

    public static GridManager instance
    {
        get
        {
            return Instance;
        }
    }

    [SerializeField]
    private GameObject TilePrefab;

    [SerializeField]
    private int Rows = 5;
    public int rows
    {
        get
        {
            return Rows;
        }
    }

    [SerializeField]
    private int Cols = 5;
    public int cols
    {
        get
        {
            return Cols;
        }
    }


    private float TileSize = 1.05f;
    public float tileSize
    {
        get
        {
            return TileSize;
        }
    }

    public Vector2 randomEnemyPosition
    {
        get
        {
            int randomInt = UnityEngine.Random.Range(0, Cols - 1);
            float posX = randomInt * TileSize - ((Cols - 1) * TileSize) / 2;
            float posY = ((Rows - 1) * TileSize) / 2;

            return new Vector2(posX, posY);
        }
    }


    public Vector2 initialPlayerPosition
    {
        get
        {
            float posX = -((Cols - 1) * TileSize) / 2;
            float posY = Rows * -TileSize + ((Rows - 1) * TileSize) / 2;

            return new Vector2(posX, posY);
        }
    }



    private void Awake()
    {
        Instance = this;
    }



    void Start()
    {
        GenerateGrid();
        
    }

    private void GenerateGrid()
    {


        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {

                GameObject tile = Instantiate(TilePrefab, transform);

                float posX = col * TileSize - ((Cols-1) * TileSize)/2;
                float posY = row * -TileSize + ((Rows-1) * TileSize)/2;

                tile.transform.position = new Vector2(posX, posY);



            }
        }
    }



  
    
}
