using UnityEngine;

public class JebakanMusuh : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasDropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
    }

    public void Drop()
    {
        if (!hasDropped)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            hasDropped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasDropped && other.CompareTag("Ground"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
    }
}
