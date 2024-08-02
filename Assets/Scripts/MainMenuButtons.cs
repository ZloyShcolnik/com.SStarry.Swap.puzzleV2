using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void HandlePlayButtonClick()
    {
        SceneManager.LoadScene("PickLevelsScene");
    }
    
    public void HandleRulesClick()
    {
        SceneManager.LoadScene("Rules");
    }
    
    public void HandleOptionsClick()
    {
        SceneManager.LoadScene("Options");
    }
    
    public void HandleExitClick()
    {
      Application.Quit();
    }
    
    public void HandlePolicyClick()
    {
        SceneManager.LoadScene("Policy");
    }
}
