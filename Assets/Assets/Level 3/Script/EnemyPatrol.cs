using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 2f;
    public float patrolTime = 3f;

    private float timer;
    private int direction = 1;

    void Start()
    {
        timer = patrolTime;

        if (animator != null)
        {
            animator.SetBool("isWalking", true); // nyalain animasi jalan
        }
    }

    void Update()
    {
        // Jalan ke kanan atau kiri
        transform.Translate(Vector2.right * walkSpeed * direction * Time.deltaTime);

        // Timer untuk ganti arah
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction *= -1; // balik arah
            Flip();          // balikkan tampilan visual
            timer = patrolTime;
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jebakan"))
        {
            Destroy(gameObject); // langsung musnahkan tanpa animasi
        }
    }
}
