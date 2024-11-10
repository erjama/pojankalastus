using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CreditTextsController CreditTextsController;
    public GameObject CreditsPanel;
    public GameObject CreditsTextControllerContainer;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("StoryScene");
        //SceneManager.LoadSceneAsync("River");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            CreditsPanel.SetActive(false);
        }
    }

    public void ShowCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
