using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    private static Player Instance;
    public static Player instance
    {
        get
        {
            return Instance;
        }
    }

    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform FirePoint;
    
    [SerializeField]
    private float FireRate = 0.6f;
    private float NextTime = 0.0f;

    private int Points = 0;
    public int points
    {
       get
        {
            return Points;
        }
    }


    [SerializeField]
    private Vector2 TilePosition = new Vector2(0, 0);


    private static event UnityAction<int> OnAddPointsEvent;
    public static UnityAction<int> onAddPointsEvent
    {
        get
        {
            return OnAddPointsEvent;
        }
        set
        {
            OnAddPointsEvent = value;
        }
    }
   


    

    
    void Awake()
    {
        Instance = this;
    }


    void Start()
    {

        transform.position = GridManager.instance.initialPlayerPosition;
        TilePosition = new Vector2(0, 0);

        MobileInputs.OnRightPressed += MobileInputRight;
        MobileInputs.OnLeftPressed += MobileInputLeft;
        MobileInputs.OnFirePressed += MobileInputFire;

    }


    void MobileInputRight()
    {
        moveHorizontal();
    }

    void MobileInputLeft()
    {
        moveHorizontal(true);
    }

    void MobileInputFire()
    {
        Fire();
    }
   


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.D))
        {
            moveHorizontal();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveHorizontal(true);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Fire();
        }

    }



    void moveHorizontal(bool left = false)
    {

        float tileSize = GridManager.instance.tileSize;

        if(!left)
        {
            if (TilePosition.x < GridManager.instance.cols - 1)
            {

                transform.position = new Vector2(transform.position.x + tileSize, transform.position.y);
                TilePosition = new Vector2(TilePosition.x + 1, 0);

            }

        }
        else
        {
            if (TilePosition.x > 0)
            {

                transform.position = new Vector2(transform.position.x - tileSize, transform.position.y);
                TilePosition = new Vector2(TilePosition.x - 1, 0);

            }
        }
       
    }


    void Fire ()
    {

        if (Time.time > NextTime)
        {

            var bullet = (GameObject)Instantiate(BulletPrefab);
            bullet.transform.position = FirePoint.position;

            NextTime = Time.time + FireRate;

        }

    }



    public void AddPoints(int value)
    {
        Points += value;
        OnAddPointsEvent?.Invoke(Points);
    }

    void OnDestroy()
    {

        MobileInputs.OnRightPressed -= MobileInputRight;
        MobileInputs.OnLeftPressed -= MobileInputLeft;
        MobileInputs.OnFirePressed -= MobileInputFire;

    }



}
