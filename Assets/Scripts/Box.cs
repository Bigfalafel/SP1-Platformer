using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fallAcceleration = 10f;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        
        if (rb.velocity.y < 0 && rb.velocity.y > -50)
        {
            rb.AddForce(new Vector2(0, -fallAcceleration));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             rb.constraints = RigidbodyConstraints2D.FreezePositionX;
             
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BoxKiller"))
        {
            Destroy(gameObject);
        }
    }
}   
