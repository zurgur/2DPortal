using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public static bool GameIsOver = false;

    public GameObject gameOverMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsOver = true;
        }
    }
    public void Resume()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
