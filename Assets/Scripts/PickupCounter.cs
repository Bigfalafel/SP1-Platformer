using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PickupCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text pickUpText;
    public int pickUps = 0;

    private void Start()
    {
        pickUpText.text = "" + pickUps + "/9";
    }
    public void PickUp()
    {
        pickUps++;
        pickUpText.text = "" + pickUps + "/9";
    }
}
