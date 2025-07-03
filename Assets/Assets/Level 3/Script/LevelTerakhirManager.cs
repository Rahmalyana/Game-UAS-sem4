using UnityEngine;

public class LevelTerakhirManager : MonoBehaviour
{
    private bool cowokSampai = false;
    private bool cewekSampai = false;
    private bool levelSelesai = false;

    public GameObject panelSelesai; // UI panel selesai level (optional)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelSelesai) return;

        if (other.CompareTag("cowok"))
            cowokSampai = true;

        if (other.CompareTag("cewek"))
            cewekSampai = true;

        CekSelesai();
    }

    void CekSelesai()
    {
        if (cowokSampai && cewekSampai && GameManager.Instance.heartCount >= 1)
        {
            levelSelesai = true;
            Debug.Log("🎉 Level Terakhir Selesai!");

            if (panelSelesai != null)
                panelSelesai.SetActive(true);

            // Optional: pause game
            // Time.timeScale = 0f;
        }
    }
}
