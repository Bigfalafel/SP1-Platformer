using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settings;
   




    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        creditsPanel.SetActive(true);
    }
    public void Settings()
    {
        settings.SetActive(true);
    }
    public void Back()
    {
       
            creditsPanel.SetActive(false);
       
       
            settings.SetActive(false);
          
        
    }
    
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    
    

}
