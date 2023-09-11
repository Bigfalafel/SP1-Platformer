using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int damageGiven = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            other.transform.position = spawnPosition.position;
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(damageGiven);
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
