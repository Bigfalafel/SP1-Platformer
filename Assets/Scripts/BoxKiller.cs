using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKiller : MonoBehaviour
{
    [SerializeField] BoxSpawner BoxerSpawner1;
    [SerializeField] BoxSpawner BoxerSpawner2;
    private AudioSource AudioSource;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            AudioSource.Play();
            BoxerSpawner1.SpawnedBox = 0;
            BoxerSpawner2.SpawnedBox = 0;
            Destroy(other.gameObject);
        }
    }
}