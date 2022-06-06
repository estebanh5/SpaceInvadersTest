using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MobileInputs : MonoBehaviour
{

    [SerializeField]
    private Button ButtonLeft;
    [SerializeField]
    private Button ButtonRight;
    [SerializeField]
    private Button ButtonFire;



    public static event UnityAction OnLeftPressed;


    public static event UnityAction OnRightPressed;


    public static event UnityAction OnFirePressed;




    void Start()
    {
        ButtonLeft.onClick.AddListener(() =>
        {

            OnLeftPressed?.Invoke();
        });

        ButtonRight.onClick.AddListener(() =>
        {

            OnRightPressed?.Invoke();
        });


        ButtonFire.onClick.AddListener(() =>
        {
            OnFirePressed?.Invoke();
        });
    }

    
}
