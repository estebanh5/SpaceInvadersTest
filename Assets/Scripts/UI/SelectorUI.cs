using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorUI : MonoBehaviour
{

    [SerializeField]
    private Button ButtonLevel1;

    [SerializeField]
    private Button ButtonLevel2;

    [SerializeField]
    private Button ButtonCredits;


    void Start()
    {
        ButtonLevel1.onClick.AddListener(() =>
        {

            ScreenManager.LoadGame(1);

        });


        ButtonLevel2.onClick.AddListener(() =>
        {
            ScreenManager.LoadGame(2);
        });

        ButtonCredits.onClick.AddListener(() =>
        {
            ScreenManager.LoadCredits();
        });

    }


   
}
