using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float vertical;
    private float horizontal;

    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    private bool isFacingRight = true;
    private AudioSource audioSource;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private GameObject jumpParticles;
    [SerializeField] private float fallAcceleration = 10f;

    public bool isJumping;

    [Header("Physics")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask Ground;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    private void Update()
    {
       
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        var jumpInput = Input.GetKeyDown(KeyCode.Space);
       

        if (jumpInput && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           
        }
      

       


        Flip();


    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground);
    }
    private void FixedUpdate()
    {
       

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (IsGrounded() && rb.velocity.x == 0)
        {

            audioSource.Pause();

        }
        else
        {
            audioSource.UnPause();
        }
        if (rb.velocity.y < 0 && rb.velocity.y > -100)
        {
            rb.AddForce(new Vector2(0, -fallAcceleration));
        }
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
}
