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
            // ❌ Kalau heart belum diambil, batal masuk
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
        Debug.Log("🎉 LEVEL SELESAI!");
        // Bisa ditambah panel selesai di sini
        // Atau biarkan kosong karena ini level terakhir
    }
}
