using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject dialougeBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 20;
    [SerializeField] private int levelToLoad = 2;

    private Animator anim;
    private bool levelIsLoading = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.CompareTag("Player"))
        {
            
            if (other.GetComponent<PlayerMovement>().bananasCollected >= questGoal)
            {
                dialougeBox.SetActive(true);
                finishedText.SetActive(true);
                anim.SetTrigger("Flag");
                Invoke("LoadNextLevel", 3f);
                levelIsLoading = true;

            }
            else
            {
                dialougeBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelIsLoading)
        {
            unfinishedText.SetActive(false);
            finishedText.SetActive(false);
            dialougeBox.SetActive(false);
        }
    }
}