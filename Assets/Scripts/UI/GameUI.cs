using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    [SerializeField]
    private Text PointsText;

    void Start()
    {

        Player.onAddPointsEvent += PointsAddedToPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Player.onAddPointsEvent -= PointsAddedToPlayer;
    }


    void PointsAddedToPlayer(int currentvalue)
    {
        PointsText.text = $"{currentvalue}";
    }
}
