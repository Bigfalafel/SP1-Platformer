using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] public bool spawnBox = false;

    private GameObject SpawnedBox;

    private void Update()
    {
        if (spawnBox && SpawnedBox == null)
        {
           
            var SpawnedBox = Instantiate(Box, new Vector3(transform.localPosition.x, transform.localPosition.y - 1, 0), Quaternion.identity);
            
            spawnBox = false;
            return;
        }
        else
        {
            Destroy(SpawnedBox);
            
        }
        
    }


}
