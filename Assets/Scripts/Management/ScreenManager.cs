using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{



    [SerializeField]
    private float SplashDuration = 3.0f;

    void Awake()
    {

        DontDestroyOnLoad(this);
        
    }


    void Start()
    {
        if(SceneManager.GetActiveScene().name == "SplashScene")
        {
            StartCoroutine(WaitToEndSplashCoroutine());
        }
       
    }


    private IEnumerator WaitToEndSplashCoroutine()
    {

        yield return new WaitForSeconds(SplashDuration);

        SceneManager.LoadScene("SelectorScene");
    }

    public static void LoadGame(int level)
    {
        LevelManager.currentLevel = level;
        SceneManager.LoadScene("GameScene");
    }


    public static void ReloadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void LoadSelector()
    {
        SceneManager.LoadScene("SelectorScene");
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");

    }
}
