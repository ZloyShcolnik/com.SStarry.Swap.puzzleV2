using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{
    // Start is called before the first frame update

    private Button _button;

    public static bool IsPolicyAccepted = false;

    [SerializeField] private string _sceneName;

    public bool IsPolicyButton = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(GoToMainMenu);
    }

    // Update is called once per frame
    void OnDisable()
    {
        _button.onClick.RemoveListener(GoToMainMenu);
    }

    private void GoToMainMenu()
    {
        if(IsPolicyButton)
            return;
        SceneManager.LoadScene(_sceneName);
    }

    public void PickScene()
    {
        if(IsPolicyAccepted)
        SceneManager.LoadScene("MainMenu");
        else
        {
            SceneManager.LoadScene("AppFree");
        }
    }

    public void AcceptPolicy()
    {
        IsPolicyAccepted = true;
    }
}
