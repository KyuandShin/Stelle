using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float moveSpeed = 2f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isGrounded = false;

    Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower, rb.linearVelocity.z);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, verticalInput * moveSpeed);
        rb.linearVelocity = moveDirection;

        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        animator.SetFloat("zVelocity", Math.Abs(rb.linearVelocity.z)); // For up/down movement
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        // Optional: Boolean for walking
        bool isWalking = Mathf.Abs(rb.linearVelocity.x) > 0.1f || Mathf.Abs(rb.linearVelocity.z) > 0.1f;
        animator.SetBool("isWalking", isWalking);
    }


    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
