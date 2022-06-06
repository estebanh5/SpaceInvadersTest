using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int EnemyType = 0;
    public int enemyType
    {
        get
        {
            return EnemyType;
        }
    }

    private List<Color> ColorByType = new List<Color>() { Color.green, Color.blue, Color.red};

    [SerializeField]
    private float MoveRate = 1.0f;
    public float moveRate
    {
        get
        {
            return MoveRate;
        }
    }

    private Vector2 TilePosition;


    private float NextTime = 0.0f;

    private bool IsGameOver = false;
    


    void Start()
    {
        NextTime = Time.time + MoveRate;

        int type = Random.Range(0, 2);

        EnemyType = type;
        GetComponent<SpriteRenderer>().color = ColorByType[type];



    }


    void Update()
    {

        if(Time.time > NextTime)
        {
            Move();
            NextTime = Time.time + MoveRate;
        }

        if (TilePosition.y >= GridManager.instance.rows)
        {

            if(!IsGameOver)
            {
                GameManager.instance.GameOver();
                IsGameOver = true;
            }

        }
        
    }


    private void Move()
    {

        float tileSize = GridManager.instance.tileSize;

        transform.position = new Vector2(transform.position.x, transform.position.y - tileSize);
        TilePosition = new Vector2(TilePosition.x, TilePosition.y + 1);

        
    }

    public void Destroy()
    {
        print("Enemy destroyed");

        int factor = 1;

        if(TilePosition.y == 0)
        {
            factor = 3;
        }
        else if(TilePosition.y == GridManager.instance.rows -1)
        {
            factor = 1;
        }else
        {
            factor = 1;
        }

        print($"Added {factor} points");


        Player.instance.AddPoints((enemyType+1) * factor);
        

        GameObject.Destroy(gameObject);
    }

}
