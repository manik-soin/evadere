
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{

    public static int health = 0;
    public string nextScene;
    public int delay;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            ChangeToScene(nextScene);
        }
    }

    public void ChangeToScene(string sceneToChangeTo)
    {
        StartCoroutine(DoChangeScene(sceneToChangeTo, delay));
    }
    IEnumerator DoChangeScene(string sceneToChangeTo, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
