using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text totalSkorText;
    public Text bestSkorText;

    void Start()
    {
        // Ambil total star yang disimpan dari GameManager
        int totalStar = PlayerPrefs.GetInt("StarTotal", 0);
        int totalSkor = totalStar * 5;

        
        Debug.Log("StarTotal: " + totalStar);         // <-- tambahkan ini
        Debug.Log("TotalSkor: " + totalSkor);  

        // Ambil best score yang pernah dicapai
        int bestSkor = PlayerPrefs.GetInt("BestScore", 0);

        // Jika skor sekarang lebih tinggi, simpan sebagai best score baru
        if (totalSkor > bestSkor)
        {
            bestSkor = totalSkor;
            PlayerPrefs.SetInt("BestScore", bestSkor);
            PlayerPrefs.Save();
        }

        // Tampilkan ke UI
        if (totalSkorText != null)
            totalSkorText.text = "Total Skor: " + totalSkor;

        if (bestSkorText != null)
            bestSkorText.text = "Best Skor: " + bestSkor;
    }
}
