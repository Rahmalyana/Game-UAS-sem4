using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadSceneAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // drag video player ke sini
    public string sceneToLoad;      // nama scene yang akan dibuka

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
