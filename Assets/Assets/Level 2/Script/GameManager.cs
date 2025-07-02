using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int starCount = 0;
    public int heartCount = 0;

    public Text starText;
    public Text heartText;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void AddStar()
    {
        starCount++;
        UpdateUI();
    }

    public void AddHeart()
    {
        heartCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (starText) starText.text = starCount.ToString();
        if (heartText) heartText.text = heartCount.ToString();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }
}
