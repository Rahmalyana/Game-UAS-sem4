using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Halaman : MonoBehaviour
{
    private bool showExitPopup = false;

    [Header("Level Buttons (UI)")]
    public Button buttonLevel1;
    public Button buttonLevel2;
    public Button buttonLevel3;

    [Header("Level Scene Names")]
    public string EnterScene;
    public string EscapeScene;
    public bool isEscapeForQuit = false;
    bool showResetConfirm = false;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // // === RESET OTOMATIS JIKA SEMUA LEVEL SUDAH DIBUKA ===
        // if (unlockedLevel >= 3)
        // {
        //     Debug.Log("Semua level sudah terbuka. Reset progress dan mulai dari Level-1...");
        //     PlayerPrefs.DeleteAll();
        //     PlayerPrefs.Save();
        //     SceneManager.LoadScene("PilihLevel");
        //     return; // hentikan eksekusi lanjut
        // }

        // Set button level
        SetButtonState(buttonLevel1, true);
        SetButtonState(buttonLevel2, unlockedLevel >= 2);
        SetButtonState(buttonLevel3, unlockedLevel >= 3);
    }

    void SetButtonState(Button button, bool isUnlocked)
    {
        if (button == null) return;

        button.interactable = isUnlocked;

        var image = button.GetComponent<Image>();
        if (image != null)
        {
            Color c = image.color;
            c.a = isUnlocked ? 1f : 0.4f;
            image.color = c;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(EnterScene);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                showExitPopup = true;
            }
            else
            {
                SceneManager.LoadScene(EscapeScene);
            }
        }
    }

    // === Navigasi Scene ===
    public void Home() => SceneManager.LoadScene("Home");
    public void PilihLevel() => SceneManager.LoadScene("PilihLevel");
    public void Credit() => SceneManager.LoadScene("Credit");
    public void Help() => SceneManager.LoadScene("Help");
    public void Exit() => showExitPopup = true;
    public void Kembali() => SceneManager.LoadScene("PilihLevel");
    public void CutScene() => SceneManager.LoadScene("CutScene");
    public void OpenLevel1()
    {
        PlayerPrefs.SetString("LastLevel", "Level-1");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level-1");
    }

    public void OpenLevel2()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 2)
        {
            PlayerPrefs.SetString("LastLevel", "Level-2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level-2");
        }
    }

    public void OpenLevel3()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 3)
        {
            PlayerPrefs.SetString("LastLevel", "Level-3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level-3");
        }
    }

    public void UlangiLevel()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level-1");
        SceneManager.LoadScene(lastLevel);
    }

    public void ResetProgress()
    {
        Debug.Log("Progress di-reset manual.");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UnlockedLevel", 1); // default
        PlayerPrefs.Save();
        SceneManager.LoadScene("PilihLevel"); // Atau ganti ke scene awal kamu
    }
    public void ResetButtonPressed()
    {
        showResetConfirm = true;
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

        if (showResetConfirm)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), "Yakin reset progress?");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 80, 30), "Ya"))
            {
                ResetProgress();
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 20, Screen.height / 2, 80, 30), "Tidak"))
            {
                showResetConfirm = false;
            }
        }
    }
}
