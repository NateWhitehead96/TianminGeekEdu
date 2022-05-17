using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // load the first scene
    }
    public void ExitGame()
    {
        Application.Quit(); // close the game, only works if a standalone build
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0); // load main menu
    }
}
