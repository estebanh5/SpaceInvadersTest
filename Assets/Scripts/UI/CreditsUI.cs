using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{

    [SerializeField]
    private Button ButtonBackToMenu;
    

    void Start()
    {
        ButtonBackToMenu.onClick.AddListener(() =>
        {
            ScreenManager.LoadSelector();
        });
    }

  
   
}
