using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    private bool showExitPopup = false;

    [Header("Level Buttons")]
    public GameObject buttonLevel1;
    public GameObject buttonLevel2;
    public GameObject buttonLevel3;

    [Header("Lock Sprite (assign di Inspector)")]
    public Sprite lockSprite;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Level 1 selalu aktif
        SetButtonState(buttonLevel1, true);

        // Level 2 hanya aktif jika sudah unlock
        SetButtonState(buttonLevel2, unlockedLevel >= 2);

        // Level 3 hanya aktif jika sudah unlock
        SetButtonState(buttonLevel3, unlockedLevel >= 3);
    }

    void SetButtonState(GameObject button, bool isUnlocked)
    {
        if (button == null) return;

        // Dapatkan SpriteRenderer
        var sr = button.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = isUnlocked ? 1f : 0.4f; // jika terkunci, buat transparan
            sr.color = c;
        }

        // Nonaktifkan Collider2D jika terkunci
        var col = button.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = isUnlocked;
    }


    void OnMouseDown()
    {
        string objectName = gameObject.name;
        string currentScene = SceneManager.GetActiveScene().name;

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Debug.Log($"Klik objek: {objectName} di scene: {currentScene}");

        switch (objectName)
        {
            case "Button_Kredit":
                SceneManager.LoadScene("credit");
                break;

            case "Button_Play":
                SceneManager.LoadScene("main menu");
                break;

            case "Level-1":
                PlayerPrefs.SetString("LastPlayedLevel", "Level-1");
                SceneManager.LoadScene("Level-1");
                break;

            case "Level-2":
                if (unlockedLevel >= 2)
                {
                    PlayerPrefs.SetString("LastPlayedLevel", "Level-2");
                    SceneManager.LoadScene("Level-2");
                }
                break;

            case "Level-3":
                if (unlockedLevel >= 3)
                {
                    PlayerPrefs.SetString("LastPlayedLevel", "Level-3");
                    SceneManager.LoadScene("Level-3");
                }
                break;

            case "Button_Keluar":
                if (currentScene == "main menu")
                {
                    SceneManager.LoadScene("opening");
                }
                else if (currentScene == "opening")
                {
                    showExitPopup = true;
                }
                break;

            case "Button_Home":
                SceneManager.LoadScene("opening");
                break;

            case "Button_Exit":
                SceneManager.LoadScene("main menu");
                break;
            
            case "Button_Ulangi":
                string lastLevel = PlayerPrefs.GetString("LastPlayedLevel", "Level-1");
                SceneManager.LoadScene(lastLevel);
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