using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    public void UpdateCoinsText(string coins)
    {
        coinsText.text = "Coins: " + coins;
    }
}
