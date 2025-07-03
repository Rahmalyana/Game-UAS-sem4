using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak1 : MonoBehaviour
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

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
{
    float horizontalInput = 0f;

    // Deteksi tombol slide
    isSliding = Input.GetKey(KeyCode.S) && grounded && !isJumping;

    if (!isSliding)
    {
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;
    }
    else
    {
        // Boleh gerak saat sliding juga
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;
    }

    float currentSpeed = isSliding ? speed * 0.8f : speed;
    body.velocity = new Vector2(horizontalInput * currentSpeed, body.velocity.y);

    // Flip karakter
    if (horizontalInput > 0.01f)
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

    // Jump
    if (Input.GetKeyDown(KeyCode.W) && grounded)
    {
        Jump();
    }

    // Batasi tinggi lompatan
    if (isJumping && transform.position.y > jumpStartY + maxJumpHeight && body.velocity.y > 0)
    {
        body.velocity = new Vector2(body.velocity.x, 0f);
        isJumping = false;
    }

    // Update animator
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
            Debug.Log("Grounded: " + grounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            Debug.Log("Jumping: " + isJumping);
        }
    }
    
}
