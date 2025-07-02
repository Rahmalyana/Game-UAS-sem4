using UnityEngine;

public class JebakanMusuh : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasDropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Drop()
    {
        if (!hasDropped)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            hasDropped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasDropped)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
    }
}
