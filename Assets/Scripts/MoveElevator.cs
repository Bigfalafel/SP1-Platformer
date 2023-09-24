using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevator : MonoBehaviour
{
   
    public Elevator Elevator;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            audioSource.Play();
            Elevator.Move = true;
           
        }

    }
}
