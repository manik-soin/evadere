using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string nextScene;
    public void GameStart()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit Successfully! ");
        Application.Quit();
    }
}
