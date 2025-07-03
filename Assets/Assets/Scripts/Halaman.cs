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

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Level 1 selalu aktif
        SetButtonState(buttonLevel1, true);
        SetButtonState(buttonLevel2, unlockedLevel >= 2);
        SetButtonState(buttonLevel3, unlockedLevel >= 3);
    }

    void SetButtonState(Button button, bool isUnlocked)
    {
        if (button == null) return;

        // Aktifkan atau nonaktifkan interaksi tombol
        button.interactable = isUnlocked;

        // Opsional: ubah transparansi visual (warna gambar)
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

    // === Fungsi Navigasi Scene ===
    public void Home() => SceneManager.LoadScene("Home");
    public void PilihLevel() => SceneManager.LoadScene("PilihLevel");
    public void Credit() => SceneManager.LoadScene("Credit");
    public void Help() => SceneManager.LoadScene("Help");
    public void Exit() => showExitPopup = true;
    public void Kembali() => SceneManager.LoadScene("PilihLevel");
    public void KembaliKeMenuPlay() => SceneManager.LoadScene("MenuPlay");

    public void OpenLevel1() => SceneManager.LoadScene("Level-1");
    public void OpenLevel2()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 2)
            SceneManager.LoadScene("Level-2");
    }

    public void OpenLevel3()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 3)
            SceneManager.LoadScene("Level-3");
    }

    public void UlangiLevel()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level-1");
        SceneManager.LoadScene(lastLevel);
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
