using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseUI;

    public GameObject player;
    float health;

    public bool gameIsOver;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        health = player.GetComponent<PlayerNeeds>().health;

        Debug.Log(health);
        
        if (health <= 0)
        {
            gameIsOver = true;
        }

        if (gameIsOver)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
