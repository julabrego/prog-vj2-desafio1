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

    public void UpdateLifeIconsHUD(int lives) {
        if (isLifesContainerEmpty())
        {
            loadLifesContainer(lives);
            return;
        }

        if(liveIconsQuantity() > lives)
        {
            removeLastLiveIcon();
        }
        else
        {
            createLiveIcon();
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

    private bool isLifesContainerEmpty()
    {
        return liveIconsContainer.transform.childCount == 0;
    }

    private void loadLifesContainer(int iconsQuantity)
    {
        for(int i = 0; i < iconsQuantity; i++)
        {
            Instantiate(liveIcon, liveIconsContainer.transform);
        }
    }

    private int liveIconsQuantity()
    {
        return liveIconsContainer.transform.childCount;
    }

    private void removeLastLiveIcon()
    {
        Transform container = liveIconsContainer.transform;
        GameObject.Destroy(container.GetChild(container.childCount - 1).gameObject);
    }

    private void createLiveIcon()
    {
        Instantiate(liveIcon, liveIconsContainer.transform);
    }
}
