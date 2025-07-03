using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToMainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC ditekan, pindah ke main menu");
            SceneManager.LoadScene("PilihLevel");
        }
    }
}


