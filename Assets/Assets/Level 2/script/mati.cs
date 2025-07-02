using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // <-- penting untuk pakai IEnumerator

public class PlayerDeath : MonoBehaviour
{
    public float delayBeforeGameOver = 1.5f; // durasi delay sebelum pindah scene

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            Debug.Log("Game Over: Terkena bahaya!");
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        // Bisa tambahkan efek animasi mati di sini
        yield return new WaitForSeconds(delayBeforeGameOver);
        SceneManager.LoadScene("GameOver");
    }
}
