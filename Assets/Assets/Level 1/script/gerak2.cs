using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak2 : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float maxJumpHeight = 5f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Player 2: kontrol dengan arrow key
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip karakter
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }

        // Arrow Up untuk loncat
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }

        // Batas tinggi loncatan
        if (transform.position.y > maxJumpHeight && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, 0f);
        }

        // Update animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
