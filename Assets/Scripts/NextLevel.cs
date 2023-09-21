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


    void Start()
    {
        currentTarget = Target1;

    }
    void FixedUpdate()
    {
        if(Ready >= 2)
        {
            Move = true;
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

}
