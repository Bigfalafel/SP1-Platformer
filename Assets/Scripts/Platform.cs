using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Transform Target1, Target2;
    [SerializeField] private float moveSpeed = 2.0f;
    public bool Move = false;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = Target1;
    }

   
    void FixedUpdate()
    {   if (Move)
        {
            if (transform.position == Target1.position)
            {
                currentTarget = Target2;
            }
            if (transform.position == Target2.position)
            {
                currentTarget = Target1;
            }

            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y || other.gameObject.CompareTag("Player2") && other.transform.position.y > transform.position.y)
        {
            
            other.transform.SetParent(transform);
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.interpolation = RigidbodyInterpolation2D.None;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            other.transform.SetParent(null);
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }
}
