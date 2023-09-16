using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] public bool spawnBox = false;
   

    private void Update()
    {   if (spawnBox == true)
        {
            Instantiate(Box, new Vector3(transform.localPosition.x, transform.localPosition.y, 0), Quaternion.identity);
            spawnBox = false;
        }
    }
}
