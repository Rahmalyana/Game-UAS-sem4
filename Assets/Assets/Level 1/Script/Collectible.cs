using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum ItemType { Star, Heart }
    public ItemType itemType;

    public AudioClip starSound;
    public AudioClip heartSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cowok") || other.CompareTag("cewek"))
        {
            switch (itemType)
            {
                case ItemType.Star:
                    Debug.Log("Star Collected!");
                    GameManager.Instance.PlaySound(starSound);
                    GameManager.Instance.AddStar();
                    break;

                case ItemType.Heart:
                    Debug.Log("Heart Collected!");
                    GameManager.Instance.PlaySound(heartSound);
                    GameManager.Instance.AddHeart();
                    break;
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
