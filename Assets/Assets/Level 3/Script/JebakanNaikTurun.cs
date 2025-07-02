using UnityEngine;

public class JebakanNaikTurun : MonoBehaviour
{
    public float speed = 2f;                // Kecepatan naik-turun
    public float moveDistance = 3f;         // Jarak naik dari posisi dasar
    private Vector3 startPos;               // Posisi saat menyentuh tanah
    private bool isActivated = false;       // True setelah jatuh dan menyentuh tanah
    private bool movingUp = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Aktifkan gravitasi biar jatuh dulu
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f; // pastikan ini > 0
    }

    void Update()
    {
        if (!isActivated) return; // Tunggu sampai menyentuh tanah dulu

        float movement = speed * Time.deltaTime;

        if (movingUp)
        {
            transform.position += new Vector3(0, movement, 0);
            if (transform.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0, movement, 0);
            if (transform.position.y <= startPos.y)
            {
                transform.position = startPos; // presisi
                movingUp = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActivated)
        {
            // Pastikan hanya aktif saat menyentuh objek tertentu, misalnya "Ground"
            if (collision.collider.CompareTag("Ground"))
            {
                startPos = transform.position;
                isActivated = true;

                // Nonaktifkan physics agar bisa digerakkan manual
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
