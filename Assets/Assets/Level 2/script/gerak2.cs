using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak2 : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private float jumpStartY;
    private bool isJumping = false;
    private bool isSliding = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float maxJumpHeight = 5f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = 0f;

        // Cek apakah sliding
        isSliding = Input.GetKey(KeyCode.DownArrow) && grounded && !isJumping;

        // Input gerak kanan/kiri
        if (!isSliding)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1f;
            else if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1f;
        }
        else
        {
            // Sliding bisa sambil gerak
            if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1f;
            else if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1f;
        }

        float currentSpeed = isSliding ? speed * 0.8f : speed;
        body.velocity = new Vector2(horizontalInput * currentSpeed, body.velocity.y);

        // Flip arah karakter
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

        // Loncat
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }

        // Batasi tinggi loncatan
        if (isJumping && transform.position.y > jumpStartY + maxJumpHeight && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, 0f);
            isJumping = false;
        }

        // Update animasi
        anim.SetBool("run", horizontalInput != 0 && !isSliding);
        anim.SetBool("grounded", grounded);
        anim.SetBool("isSliding", isSliding);
    }

    private void Jump()
    {
        jumpStartY = transform.position.y;
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        grounded = false;
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
