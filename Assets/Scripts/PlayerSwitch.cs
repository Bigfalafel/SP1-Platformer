using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public PlayerMovement Player1;
    public Player2Movement Player2;
    public bool player1Active = true;



    private void Start()
    {
        Player2.enabled = false;
    }

    void Update()
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
            Player1.enabled = false;
            Player2.enabled = true;
            player1Active = false;
        }
        else
        {
            Player1.enabled = true;
            Player2.enabled = false;
            player1Active = true;
        }
    }
}
