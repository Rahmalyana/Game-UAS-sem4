using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    private bool showExitPopup = false;

    void OnMouseDown()
    {
        string objectName = gameObject.name;
        string currentScene = SceneManager.GetActiveScene().name;

        Debug.Log($"Klik objek: {objectName} di scene: {currentScene}");

        switch (objectName)
        {
            case "Button_28":
                SceneManager.LoadScene("credit");
                break;

            case "Button_16":
                SceneManager.LoadScene("main menu");
                break;

            case "12":
                SceneManager.LoadScene("Level-2");
                break;

            case "13":
                SceneManager.LoadScene("Level-1");
                break;

            case "14":
                SceneManager.LoadScene("Level-3");
                break;

            case "Button_136":
                if (currentScene == "main menu")
                {
                    SceneManager.LoadScene("opening"); // normal behavior
                }
                else if (currentScene == "opening")
                {
                    showExitPopup = true; // show confirmation
                }
                break;

            default:
                Debug.LogWarning("Tidak ada aksi untuk objek: " + objectName);
                break;
        }
    }

    void OnGUI()
    {
        if (showExitPopup)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), "Yakin ingin keluar dari game?");

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 80, 30), "Ya"))
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }

            if (GUI.Button(new Rect(Screen.width / 2 + 20, Screen.height / 2, 80, 30), "Tidak"))
            {
                showExitPopup = false;
            }
        }
    }
}