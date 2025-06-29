using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ItemType { Star, Heart }
    public ItemType itemType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (itemType)
            {
                case ItemType.Star:
                    Debug.Log("Star Collected!");
                    // Tambah skor di sini kalau pakai sistem skor
                    GameManager.Instance.AddStar(); // ✅ Tambahkan ini
                    break;

                case ItemType.Heart:
                    Debug.Log("Heart Collected!");
                    // Tambah nyawa player di sini kalau ada sistem nyawa
                    GameManager.Instance.AddHeart(); // ✅ Tambahkan ini
                    break;
            }

            Destroy(gameObject); // Hilangkan item setelah diambil
        }
    }
}
