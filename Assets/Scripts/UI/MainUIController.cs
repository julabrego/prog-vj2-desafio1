using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private MainMenuViewShown viewSelected;
    [SerializeField] GameObject[] views;

    public void OpenCredits()
    {
        GoToOption(MainMenuViewShown.CREDITS);
    }
    public void OpenOptions()
    {
        GoToOption(MainMenuViewShown.OPTIONS);
    }

    public void OpenMainMenu()
    {
        GoToOption(MainMenuViewShown.MAIN);
    }
    private void Start()
    {
        highScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
        UpdateView();
    }

    private void GoToOption(MainMenuViewShown option)
    {
        viewSelected = option;
        UpdateView();
    }

    private void UpdateView()
    {
        switch (viewSelected) {
            case MainMenuViewShown.CREDITS:
                views[0].SetActive(false);
                views[1].SetActive(false);
                views[2].SetActive(true);
                break;
            case MainMenuViewShown.OPTIONS:
                views[0].SetActive(false);
                views[1].SetActive(true);
                views[2].SetActive(false);
                break;
            case MainMenuViewShown.MAIN:
            default:
                views[0].SetActive(true);
                views[1].SetActive(false);
                views[2].SetActive(false);
                break;
        }
    }

    public void LoadNextScene()
    {
        ApplicationManager.Instance.GoToNextScene();
    }

}

public enum MainMenuViewShown
{
    MAIN,
    OPTIONS,
    CREDITS
}