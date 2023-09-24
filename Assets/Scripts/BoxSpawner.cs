using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] public bool spawnBox = false;

    public int SpawnedBox = 0;

    private void Update()
    {
        if (spawnBox && SpawnedBox != 1)
        {
            Destroy(GameObject.FindWithTag("Box")); 
            Instantiate(Box, new Vector3(transform.localPosition.x, transform.localPosition.y - 1, 0), Quaternion.identity);
            SpawnedBox = 1;
            spawnBox = false;
           
        }
        
        
    }


}
