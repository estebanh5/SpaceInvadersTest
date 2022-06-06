using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private static GameManager Instance;
    public static GameManager instance
    {
        get
        {
            return Instance;
        }
    }

    private static int RecolectedPoints = 0;
    public static int recolectedPoints
    {
        get
        {
            return RecolectedPoints;
        }
    }
    
    [SerializeField]
    private GameObject EnemyPref;

    [SerializeField]
    private int EnemiesCount = 20;
    [SerializeField]
    private float InstanceEnemyRate = 2.0f;
    public float instanceEnemyRate
    {
        get
        {
            return InstanceEnemyRate;
        }
    }

    private float NextTime = 0.0f;

    private List<GameObject> InstantiatedEnemies = new List<GameObject>();

    private int InstantiatedCount = 0;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        RecolectedPoints = 0;
    } 


    void Update()
    {

        if(Time.time > NextTime)
        {
            if(InstantiatedEnemies.Count < EnemiesCount)
            {

                CreateEnemy();
                NextTime = Time.time + InstanceEnemyRate;
            }
            
           
        }

        if (!ExistEnemy() && InstantiatedCount == EnemiesCount)
        {
            GameOver();
        }

       
        
    }

    private bool ExistEnemy()
    {
        foreach(var enemy in InstantiatedEnemies)
        {
            if(enemy != null)
            {
                return true;
            }

        }

        return false;
    }


    private void CreateEnemy ()
    {
        var enemyPosition = GridManager.instance.randomEnemyPosition;

        var enemy = (GameObject)Instantiate(EnemyPref, transform);

        enemy.transform.position = enemyPosition;
        InstantiatedEnemies.Add(enemy);

        InstantiatedCount++;

    }

    public void GameOver()
    {
        print("Game Over!");

        ScreenManager.GameOver();
    }

    void OnDestroy()
    {
        RecolectedPoints = Player.instance.points;
    }
}
