using UnityEngine;
using UnityEngine.SceneManagement;

public class finish2 : MonoBehaviour
{
    public string playerTag; // "cewek" atau "cowok"
    public GameObject playerSprite; // Seret player visual di sini
    private static bool cewekMasuk = false;
    private static bool cowokMasuk = false;
    private static bool isLoading = false;
    private bool hasEntered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasEntered && other.CompareTag(playerTag))
        {
            hasEntered = true;
            Debug.Log($"{playerTag} masuk zona finish!");

            if (playerSprite != null)
                playerSprite.SetActive(false); // Hilangkan sprite saat finish

            if (playerTag == "cewek") cewekMasuk = true;
            if (playerTag == "cowok") cowokMasuk = true;

            CekSelesai();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            if (playerTag == "cewek") cewekMasuk = false;
            if (playerTag == "cowok") cowokMasuk = false;
        }
    }

    void CekSelesai()
    {
        if (!isLoading && cewekMasuk && cowokMasuk)
        {
            isLoading = true;
            Debug.Log("Kedua pemain masuk zona! MENANG!");
            Invoke(nameof(WinLevel), 1f);
        }
    }

    void WinLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevel", currentScene);

        // Ambil level yang sudah terbuka
        int currentUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Cek dan buka level berikutnya
        if (currentScene == "Level-2" && currentUnlocked < 3)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 3);
            Debug.Log("Level 3 telah dibuka!");
        }

        PlayerPrefs.Save();

        // Kembali ke halaman pilih level
        SceneManager.LoadScene("PilihLevel");
    }
}
