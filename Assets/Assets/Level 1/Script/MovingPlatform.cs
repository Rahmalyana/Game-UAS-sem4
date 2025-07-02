using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float amplitude = 0f;               // Jarak naik-turun
    public float speed = 0.5f;                   // Kecepatan gerak

    [Header("Vertical Offset")]
    public float yOffsetBase = 0f;             // Posisi rata-rata gerakan (menggeser naik/turun seluruh gerakan)

    private Vector3 startPos;
    private float localTimer;                  // Timer per-platform untuk gerakan independen

    void Start()
    {
        startPos = transform.position;

        // Timer awal diacak biar setiap platform mulai di posisi berbeda
        localTimer = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        localTimer += Time.deltaTime * speed;

        // Cek nilai amplitude setiap frame
        // Debug.Log($"{gameObject.name} Amplitude: {amplitude}");

        float yOffset = Mathf.Sin(localTimer) * amplitude;

        transform.position = new Vector3(
            startPos.x,
            startPos.y + yOffset + yOffsetBase,
            startPos.z
        );
    }
}
