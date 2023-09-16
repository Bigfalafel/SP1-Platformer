using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerButton : MonoBehaviour
{
    [SerializeField] BoxSpawner boxSpawner;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxSpawner.spawnBox = true;
    }


}
