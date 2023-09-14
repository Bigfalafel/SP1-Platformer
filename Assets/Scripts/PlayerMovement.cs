using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    private bool isFacingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float jumpReleaseModifier = 2f;
    [SerializeField] private GameObject jumpParticles;

    private bool isJumping;
    

    [Header("Dash")]
    [SerializeField] public float dashingForce = 8f;
    [SerializeField] public float dashingTime = 0.2f;
    [SerializeField] public float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer dashTrailRenderer;

    private bool canDash = true;
    private bool isDashing;
    private bool isDashingCooldown;

    [Header("Physics")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask Ground;
    

    private void Start()
    {
        dashTrailRenderer.emitting = false;
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        var jumpInput = Input.GetButtonDown("Jump");
        var jumpInputRelease = Input.GetButtonUp("Jump");

        if (jumpInput && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Instantiate(jumpParticles, transform.position, jumpParticles.transform.localRotation);
        }
        if (jumpInputRelease && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / jumpReleaseModifier);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (IsGrounded() && !isDashingCooldown)
        {
            canDash = true;
        }


        Flip();


    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground);
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        isDashingCooldown = true;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x, Input.GetAxisRaw("Vertical")) * dashingForce;
        dashTrailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        dashTrailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        rb.velocity = new Vector2(transform.localScale.x, 0);
        yield return new WaitForSeconds(dashingCooldown);
        isDashingCooldown = false;

    }



}