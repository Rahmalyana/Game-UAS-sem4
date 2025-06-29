using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy otomatis setelah 10 detik (opsional)
        //Destroy(gameObject, 10f);

        // Tambah sedikit dorongan ke kanan
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100f, 0f)); // arah X, nilai bisa kamu sesuaikan
    }
}
