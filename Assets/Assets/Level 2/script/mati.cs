using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public string sceneToLoad = "main menu"; // Ganti sesuai nama scene pilih level kamu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger") )
        {
            Debug.Log("Game Over: Terkena bahaya!");
            GameOver();
        }
    }

    void GameOver()
    {
        // Bisa tambahkan efek mati, animasi, delay, dll
        SceneManager.LoadScene(sceneToLoad);
        
    }
}
