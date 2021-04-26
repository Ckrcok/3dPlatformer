using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager  : MonoBehaviour
{
    public int score;
    public static GameManager instance;
    public bool paused;

    void Awake ()
    {
    if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if (paused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        GameUI.instance.TogglePauseScreen(paused);
    }

    public void AddScore (int scoreToGive)
  {
        score += scoreToGive;
        GameUI.instance.UpdateScoreText();
  }

public void LevelEnd()
  {
// is this the last level?
  if(SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
    {
  //display the win screen
      WinGame();
    }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
          }
    }

    public void WinGame()
    {
        GameUI.instance.SetEndScreen(true);
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        GameUI.instance.SetEndScreen(false);
        Time.timeScale = 0.0f;
    }

    public void ResetScore()
    {
        score = 0;
        GameUI.instance.UpdateScoreText();
    }
}
