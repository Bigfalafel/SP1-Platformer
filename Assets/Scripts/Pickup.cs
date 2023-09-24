using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Pickup : MonoBehaviour
{
    [SerializeField] private TMP_Text pickupText;


    public int pickupsCollected = 0;

    void Start()
    {
        pickupText.text = "" + pickupsCollected;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            pickupsCollected++;
            pickupText.text = "" + pickupsCollected;
            Destroy(gameObject);
        }
    }
}