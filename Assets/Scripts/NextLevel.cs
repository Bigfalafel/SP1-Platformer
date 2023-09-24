using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Transform Target1, Target2;
    [SerializeField] private float moveSpeed = 2.0f;
    public bool Move = false;
    private float Ready = 0f;
    private Transform currentTarget;
    private AudioSource AudioSource;

    void Start()
    {
        currentTarget = Target1;
        AudioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if(Ready >= 2)
        {
            AudioSource.UnPause();
            Move = true;
        }
        if(Ready != 2)
        {
            AudioSource.Pause();
        }

        if (Move)
        {

            
            if (transform.position == Target2.position)
            {
                currentTarget = Target1;
               

            }
            if (transform.position == Target1.position)
            {
                Move = false;

            }


            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }
        if (!Move)
        {
            AudioSource.Pause();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Ready++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Ready--;
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
