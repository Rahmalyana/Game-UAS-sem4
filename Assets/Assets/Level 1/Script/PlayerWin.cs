using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public GameObject playerSprite; // Seret visual player ke sini
    public static int playersInIgloo = 0; // Shared antar pemain
    private bool hasEntered = false; // Cegah double trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !hasEntered)
        {
            hasEntered = true;
            Debug.Log($"{gameObject.name} Masuk Igloo!");

            // Hilangkan visual player
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
        // Simpan nama level terakhir yang dimainkan
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevel", currentScene);

        // Ambil level keberapa yang saat ini dibuka
        int currentUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Cek apakah kita perlu unlock level berikutnya
        if (currentScene == "Level-1" && currentUnlocked < 2)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 2);
            Debug.Log("Level 2 telah dibuka!");
        }

        PlayerPrefs.Save(); // Simpan ke storage

        // Pindah ke halaman pilih level
        SceneManager.LoadScene("PilihLevel");
    }
}
