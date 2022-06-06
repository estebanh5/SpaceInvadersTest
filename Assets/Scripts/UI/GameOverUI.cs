using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text TextPoints;

    [SerializeField]
    private Button ButtonReset;

    [SerializeField]
    private Button ButtonTileScreen;
  
    void Start()
    {

        TextPoints.text = $"{GameManager.recolectedPoints}";

        ButtonReset.onClick.AddListener(() =>
        {

            ScreenManager.ReloadGame();
        });

        ButtonTileScreen.onClick.AddListener(() =>
        {

            ScreenManager.LoadSelector();
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
