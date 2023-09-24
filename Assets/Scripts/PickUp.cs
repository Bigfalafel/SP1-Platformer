using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PickUp : MonoBehaviour
{
    public PickupCounter PC;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            PC.PickUp();
            Destroy(gameObject);
        }
    }
}
