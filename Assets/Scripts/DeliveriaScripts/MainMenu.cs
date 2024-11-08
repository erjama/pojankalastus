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
        SceneManager.LoadSceneAsync("River");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CreditsPanel.SetActive(false);
            CreditsTextControllerContainer.SetActive(false);
            CreditTextsController.ResetCredits();
        }
    }

    public void ShowCredits()
    {
        CreditsPanel.SetActive(true);
        CreditsTextControllerContainer.SetActive(true);
        CreditTextsController.StartCreditTexts();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
