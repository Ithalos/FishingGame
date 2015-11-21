using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    // Loads the main level.
    public void Play()
    {
        Application.LoadLevel("MainLevel");
    }

    // Terminates the game program.
    public void Quit()
    {
        Application.Quit();
    }
}
