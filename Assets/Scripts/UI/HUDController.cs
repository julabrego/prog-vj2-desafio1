using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject liveIcon;
    [SerializeField] GameObject liveIconsContainer;

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
        coinsText.text = "Coins: " + coins;
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
