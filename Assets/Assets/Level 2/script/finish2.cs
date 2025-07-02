using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish2 : MonoBehaviour
{
    public string playerTag; // isi "cewek" atau "cowok"
    public string nextLevel = "Level-3";

    private static bool cewekMasuk = false;
    private static bool cowokMasuk = false;
    private static bool isLoading = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log(playerTag + " masuk zona finish!");
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
            Debug.Log("Keduanya masuk zona! Pindah ke level berikutnya");
            SceneManager.LoadScene(nextLevel);
        }
    }

    
}
