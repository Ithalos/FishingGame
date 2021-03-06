﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
    public GameObject pauseUI;
    public bool gameIsPaused;
    public GameOver gameOver;

    void Start()
    {
        // At the start of the game, the pause UI will be disabled and the game will run.
        pauseUI.SetActive(false);
        gameIsPaused = false;
    }


    void Update()
    {

        // Reverse pause state.
        if (Input.GetButtonDown("Pause"))
        {
            gameIsPaused = !gameIsPaused;
        }


        // Show the pause menu & stop time.
        if (gameIsPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        // Hide the pause menu & continue time. This can only happen while the player's health is more than 0. It's not very efficient to check it every update like this, but whatever, suck my dick.
        if (!gameIsPaused && !gameOver.GetComponent<GameOver>().gameIsOver)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }


    // Resume the game.
    public void Resume()
    {
        gameIsPaused = false;
    }

    // Reload the current level, thus resetting or restarting the level.
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    // Load the level called "MainMenu". This is the main menu. Hard code is hard.
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }


    // Terminate the game program.
    public void Quit()
    {
        Application.Quit();
    }
}
