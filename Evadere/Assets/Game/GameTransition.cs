
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{

    public bool finishLevel = false;
    public bool isDead = false;
    public string credits;
    public string death;

    // Update is called once per frame
    void Update()
    {
        if (finishLevel == true)
        {
            StartCoroutine(DoChangeScene(credits, 0.3f));
        } 
        else if (isDead)
        {
            
            StartCoroutine(DoChangeScene(death, 3.5f));

        }
    }

   
    IEnumerator DoChangeScene(string sceneToChangeTo, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
