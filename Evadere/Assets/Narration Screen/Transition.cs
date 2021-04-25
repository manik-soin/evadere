using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Transition : MonoBehaviour
{
    VideoPlayer video;
    public string nextScene;
   

    void Awake()
    {
      

        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
  

}
    
