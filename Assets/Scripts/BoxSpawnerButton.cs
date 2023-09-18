using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerButton : MonoBehaviour
{
    [SerializeField] BoxSpawner boxSpawner;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2")) 
        {
            
            boxSpawner.spawnBox = true;
        }
        
    }


}
