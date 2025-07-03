using UnityEngine;
using UnityEngine.SceneManagement;

public class Halaman : MonoBehaviour
{
    private bool showExitPopup = false;

    [Header("Level Buttons")]
    public GameObject buttonLevel1;
    public GameObject buttonLevel2;
    public GameObject buttonLevel3;

    [Header("Level Scene Names")]
    public string EnterScene;
    public string EscapeScene;
    public bool isEscapeForQuit = false;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        SetButtonState(buttonLevel1, true); // Level 1 selalu aktif
        SetButtonState(buttonLevel2, unlockedLevel >= 2);
        SetButtonState(buttonLevel3, unlockedLevel >= 3);
    }

    void SetButtonState(GameObject button, bool isUnlocked)
    {
        if (button == null) return;

        var sr = button.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = isUnlocked ? 1f : 0.4f;
            sr.color = c;
        }

        var col = button.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = isUnlocked;
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
                showExitPopup = true; // tampilkan popup konfirmasi
            }
            else
            {
                SceneManager.LoadScene(EscapeScene);
            }
        }
    }

    // === Fungsi Button Navigasi ===
    public void Home() => SceneManager.LoadScene("Home");
    public void PilihLevel() => SceneManager.LoadScene("PilihLevel");
    public void Credit() => SceneManager.LoadScene("Credit");

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