using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public GameObject playerSprite; // Drag sprite/child visual player ke sini
    public static int playersInIgloo = 0; // Static agar shared antar pemain

    private bool hasEntered = false; // Cegah double hit

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

            // Jika kedua pemain sudah masuk
            if (playersInIgloo >= 2)
            {
                Debug.Log("Kedua pemain masuk igloo! MENANG!");
                Invoke(nameof(WinLevel), 1f);
            }
        }
    }

    void WinLevel()
    {
        // Ganti dengan nama scene selanjutnya jika ingin pindah
        // SceneManager.LoadScene("NextScene");
        Debug.Log("LEVEL SELESAI!");
    }
}
