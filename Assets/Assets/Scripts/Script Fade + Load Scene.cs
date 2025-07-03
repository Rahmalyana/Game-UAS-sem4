using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoEndToScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public CanvasGroup fadeCanvasGroup; // drag FadePanel di sini
    public string nextSceneName = "PilihLevel";

    public float fadeDuration = 1.5f;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(FadeAndLoad());
    }

    System.Collections.IEnumerator FadeAndLoad()
    {
        // Fade in ke hitam
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        // Setelah fade hitam penuh → load scene
        SceneManager.LoadScene(nextSceneName);
    }
}
