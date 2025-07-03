using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public GameObject playerSprite; // Seret visual player ke sini
    public GameObject winPanel;     // Seret panel UI "MENANG" dari Canvas
    public static int playersInIgloo = 0; // Shared antar pemain
    private bool hasEntered = false; // Cegah double trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !hasEntered)
        {
            if (GameManager.Instance.heartCount < 1)
            {
                Debug.Log("❌ Belum ambil heart, gabisa masuk Finish.");
                return;
            }

            hasEntered = true;
            Debug.Log($"{gameObject.name} Masuk Igloo!");

            if (playerSprite != null)
                playerSprite.SetActive(false);

            playersInIgloo++;

            if (playersInIgloo >= 2)
            {
                Debug.Log("Kedua pemain masuk igloo! MENANG!");
                Invoke(nameof(WinLevel), 1f);
            }
        }
    }

    void WinLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevel", currentScene);

        int currentUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Unlock level 2 atau 3 jika perlu
        if (currentScene == "Level-1" && currentUnlocked < 2)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 2);
        }
        else if (currentScene == "Level-2" && currentUnlocked < 3)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 3);
        }

        PlayerPrefs.Save();

        // Jika ini level terakhir (Level-3), tampilkan panel menang
        if (currentScene == "Level-3")
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true); // Tampilkan panel menang
            }
            else
            {
                Debug.LogWarning("Win Panel belum di-assign ke script!");
            }
        }
        else
        {
            SceneManager.LoadScene("PilihLevel");
        }
    }
}
