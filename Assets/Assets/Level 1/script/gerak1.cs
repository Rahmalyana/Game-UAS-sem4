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
        // Hanya A dan D untuk gerak kiri dan kanan
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
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

        // Tombol W untuk loncat, hanya bisa loncat saat grounded
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        // Batasi tinggi lompatan berdasarkan jarak dari titik awal
if (isJumping && transform.position.y > jumpStartY + maxJumpHeight && body.velocity.y > 0)
{
    body.velocity = new Vector2(body.velocity.x, 0f);
    isJumping = false;
}


        // Update parameter animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
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


    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         Debug.Log("Grounded");
    //         grounded = true;
    //     }
    //     else if(!grounded)
    //     {
    //         Debug.Log("Not Grounded");
    //     }
    // }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

}
