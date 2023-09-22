using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    
    public PlayerMovement Player1;
    public Player2Movement Player2;
    public bool player1Active = true;
    private CinemachineVirtualCamera vcam;
    public PlayerSwitch PS;
    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
        if (PS.player1Active == false)
        {
            vcam.Follow = Player2.transform;

        }
        else
        {
            vcam.Follow = Player1.transform;

        }

    }

    public void SwitchPlayer()
    {
        if (player1Active)
        {
            vcam.Follow = Player2.transform;
            player1Active = false;
        }
        else
        {
            vcam.Follow = Player1.transform;
            player1Active = true;
        }
    }
}
