using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
    [SerializeField] private float smoothing = 1.0f;

    public PlayerMovement Player1;
    public Player2Movement Player2;
    public bool player1Active = true;

    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothing * Time.deltaTime);
        transform.position = newPosition;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
        
    }

    public void SwitchPlayer()
    {
        if (player1Active)
        {
            target = Player2.transform;
            player1Active = false;
        }
        else
        {
            target = Player1.transform;
            player1Active = true;
        }
    }
}
