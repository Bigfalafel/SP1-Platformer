using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fallAcceleration = 10f;
    public BoxSpawner BS;
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
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y || other.gameObject.CompareTag("Player2") && other.transform.position.y > transform.position.y || other.gameObject.CompareTag("Box") && other.transform.position.y > transform.position.y)
        {

            other.transform.SetParent(transform);
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.interpolation = RigidbodyInterpolation2D.None;
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;

        }
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2") || other.gameObject.CompareTag("Box"))
        {
            other.transform.SetParent(null);
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }

}
