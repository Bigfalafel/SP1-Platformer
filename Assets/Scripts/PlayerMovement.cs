using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private Transform LeftFoot, RightFoot, spawnPosition;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private GameObject bananaParticles, pineappleParticles, dustParticles;

    [SerializeField] private Slider Healthbar;
    [SerializeField] private Image fillColor;
    [SerializeField] private Color green, red, yellow;
    [SerializeField] private TMP_Text bananaText;

    private float horizontalValue;
    private bool isGrounded;
    private float rayDistance = 0.25f;
    private int startingHealth = 3;
    private int currentHealth = 0;
    private bool canMove;
    public int bananasCollected = 0;

    //dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private Trailrenderer tr;

    private Rigidbody2D rgbd;
    private SpriteRenderer rend;
    private Animator anim;
    private AudioSource audioSource;
    
    
    void Start()
    {
        canMove = true;
        currentHealth = startingHealth;
        bananaText.text = "" + bananasCollected + "x";
        rgbd = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
       
        if(horizontalValue < 0)
        {
            FlipSprite(true);
        }
        if (horizontalValue > 0)
        {
            FlipSprite(false);
        }

       

        if (Input.GetButtonDown("Jump") && CheckIfGrounded()== true)
        {
            Jump();
        }

        anim.SetFloat("MovementSpeed", Mathf.Abs(rgbd.velocity.x));
        anim.SetFloat("VerticalSpeed", rgbd.velocity.y);
        anim.SetBool("isGrounded", CheckIfGrounded());

       
    }
    
    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        rgbd.velocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rgbd.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Banana"))
        {
            bananasCollected++;
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(pickupSound, 0.5f);
            Instantiate(bananaParticles, other.transform.position, Quaternion.identity);
            bananaText.text = "" + bananasCollected + "x";
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Health"))
        {
            
            RestoreHealth(other.gameObject);
            
        }
    }
    private void FlipSprite(bool direction)
    {
        rend.flipX = direction;
    }
    private void Jump()
    {
        rgbd.AddForce(new Vector2(0, jumpForce));
        int randomValue = Random.Range(1, jumpSounds.Length);   
        audioSource.PlayOneShot(jumpSounds[randomValue], 0.5f);
        Instantiate(dustParticles, transform.position, dustParticles.transform.localRotation);
    }
    private void RestoreHealth(GameObject healthPickup)
    {
        if(currentHealth < startingHealth)
        {
           
            currentHealth++;
            audioSource.PlayOneShot(pickupSound, 0.5f);
            Instantiate(pineappleParticles, healthPickup.transform.position, Quaternion.identity);
            UpdateHealthbar();
            Destroy(healthPickup.gameObject);

            if(currentHealth >= startingHealth)
            {
                currentHealth = startingHealth;
            }
        }
    }
    private void UpdateHealthbar()
    {
        Healthbar.value = currentHealth;

        if (currentHealth == 3)
        {
            fillColor.color = Color.green;
        }
        if (currentHealth == 2)
        {
            fillColor.color = Color.yellow;
        }
        if (currentHealth <= 1)
        {
            fillColor.color = Color.red;
        }
        
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthbar();

        if (currentHealth <= 0)
        {
            Respawn();
           
        }
    }
    public void TakeKnockback(float knockbackForce, float upwards)
    {
        canMove = false;
        rgbd.AddForce(new Vector2(knockbackForce, upwards));
        Invoke("CanMoveAgain", 0.25f);
    }
    private void CanMoveAgain()
    {
        canMove = true;
    }
    private void Respawn()
    {
        
        currentHealth = startingHealth;
        UpdateHealthbar();
        transform.position = spawnPosition.position;
        rgbd.velocity = Vector2.zero;
       
    }
    private bool CheckIfGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftFoot.position, Vector2.down, rayDistance, whatIsGround);
        RaycastHit2D rightHit = Physics2D.Raycast(RightFoot.position, Vector2.down, rayDistance, whatIsGround);

        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || rightHit.collider != null && rightHit.collider.CompareTag("Ground"))
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
}
