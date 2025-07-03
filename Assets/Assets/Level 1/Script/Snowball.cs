using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Snowball : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 20f;         // kecepatan snowball
    [SerializeField] private float rotationSpeed = 360f; // putaran snowball (derajat per detik)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Reset dulu kecepatan kalau perlu
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Set langsung kecepatan ke arah kanan
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // Tambahkan efek rotasi searah putaran menggelinding
        rb.angularVelocity = -rotationSpeed;

        // (Opsional) Pastikan physics tidak direm oleh drag
        rb.drag = 0f;
        rb.angularDrag = 0f;
    }
}
