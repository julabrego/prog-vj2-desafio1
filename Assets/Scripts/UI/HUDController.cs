using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject liveIcon;
    [SerializeField] GameObject liveIconsContainer;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] GameObject pauseModal;

    public void UpdateLifeIconsHUD(int lives)
    {
        if (liveIconsQuantity() != lives)
        {
            cleanLivesIcons();

            for (int i = 0; i < lives; i++)
            {
                createLiveIcon();
            }
        }
    }
    public void UpdateCoinsText(string coins)
    {
        coinsText.text = "Coins: " + coins + " | Score: " + GameManager.Instance.GetScore().ToString();
    }

    public void ShowMessageText(string message)
    {
        messageText.text = message;
    }

    public void ShowGameOver(bool victory)
    {
        messageText.text = victory ? "GANASTE. Llegaste a la meta" : "GAME OVER";
    }

    private void OnEnable()
    {
        GameEvents.OnPause += PauseGame;
        GameEvents.OnResume += ResumeGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPause -= PauseGame;
        GameEvents.OnResume -= ResumeGame;
    }

    private void PauseGame()
    {
        pauseModal.gameObject.SetActive(true);
    }

    private void ResumeGame()
    {
        pauseModal.gameObject.SetActive(false);

    }


    private int liveIconsQuantity()
    {
        return liveIconsContainer.transform.childCount;
    }

    private void cleanLivesIcons()
    {
        foreach (Transform icon in liveIconsContainer.transform)
        {
            GameObject.Destroy(icon.gameObject);
        }
    }

    private void createLiveIcon()
    {
        Instantiate(liveIcon, liveIconsContainer.transform);
    }
}
