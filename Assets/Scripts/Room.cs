using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    public GameObject virtualCamera;
    public PlayerMovement Player1;
    public Player2Movement Player2;
    public PlayerSwitch PS;
    private CinemachineVirtualCamera vcam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            virtualCamera.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            virtualCamera.SetActive(false);
        }
    }


}
