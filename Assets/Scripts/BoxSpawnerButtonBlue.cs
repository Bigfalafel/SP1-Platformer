using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerButtonBlue : MonoBehaviour
{
    [SerializeField] BoxSpawner boxSpawner;
    [SerializeField] float MaxBoxes = 0f;
    float BoxesSpawned = 0f;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {

            if (BoxesSpawned < MaxBoxes)
            {
                audioSource.Play();
                boxSpawner.spawnBox = true;
                BoxesSpawned++;
            }
            else
            {
                return;
            }
        }

    }
}
