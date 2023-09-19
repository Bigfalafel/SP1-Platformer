using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartElevatorOrPlatform : MonoBehaviour
{
    public Platform Platform;
    public Elevator Elevator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            Platform.Move = true;
            Elevator.Move = true;
        }
    }
}
