using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager Instance;
    public static LevelManager instance
    {
        get
        {
            return Instance;
        }
    }

    [SerializeField]
    private List<string> LevelAssets = new List<string>();

    [SerializeField]
    private static int CurrentLevel = 1;
    public static int currentLevel
    {
        get => CurrentLevel;
        set => CurrentLevel = value;
    }

    void Awake()
    {
        Instance = this;

        GameObject obj = (GameObject)Instantiate(Resources.Load(LevelAssets[CurrentLevel - 1]), transform);
        obj.transform.localPosition = new Vector2();
    }

}
