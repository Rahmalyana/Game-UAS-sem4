using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOpening : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Opening");
        }
    }
}

