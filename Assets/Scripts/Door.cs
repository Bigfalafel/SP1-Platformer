using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{   private Animator anim;
    private bool hasPlayedAnimation = false;
    public bool Move = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
       
        if (Move && hasPlayedAnimation == false)
        {
            hasPlayedAnimation = true;
            anim.SetTrigger("Move");
        }
    }

}
