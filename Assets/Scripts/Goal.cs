using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject dialougeBox, finishedText, unfinishedText;
    [SerializeField] PickupCounter PC;
    private float Ready = 0f;
    private void Update()
    {
        if(Ready >= 2)
        {

                if (PC.pickUps >= 9)
                {
                    dialougeBox.SetActive(true);
                    finishedText.SetActive(true);
                    Invoke("LoadNextLevel", 5f);


                }
                if (PC.pickUps < 9)
                {
                    dialougeBox.SetActive(true);
                    unfinishedText.SetActive(true);
                    Invoke("LoadNextLevel", 5f);
                }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Ready++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Ready--;
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
