using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PickupCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text pickUpText;
    public int pickUps = 0;
    private AudioSource AudioSource;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        pickUpText.text = "" + pickUps + "/9";
    }
    public void PickUp()
    {
        AudioSource.Play();
        pickUps++;
        pickUpText.text = "" + pickUps + "/9";
    }
}
