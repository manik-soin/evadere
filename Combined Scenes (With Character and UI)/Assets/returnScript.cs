using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class returnScript : MonoBehaviour
{
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit Successfully! ");
        Application.Quit();
    }
}
