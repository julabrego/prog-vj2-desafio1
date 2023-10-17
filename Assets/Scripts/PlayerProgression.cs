using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField] private PlayerProgressionData progressionData;

    //--------- Events ---------- //
    [SerializeField] UnityEvent<string> OnCoinsTextChanged;
    [SerializeField] UnityEvent<string> OnMessageTriggered;

    private void Start()
    {
        progressionData.CurrentLevel = 0;
        progressionData.CurrentCoins = 0;
        progressionData.CoinsToNextLevel = 10;

        OnCoinsTextChanged.Invoke(getCurrentCoins().ToString());
    }

    public void AddCoins(int _coins)
    {
        progressionData.CurrentCoins += _coins;
        OnCoinsTextChanged.Invoke(getCurrentCoins().ToString());
    }

    public int getCurrentCoins()
    {
        return progressionData.CurrentCoins;
    }

    public bool purchaseNewLevel()
    {
        if (canCrossToNextLevel()) { 
            jumpToNextLevel();
            return true;
        }
        OnMessageTriggered.Invoke("Necesitás " + progressionData.CoinsToNextLevel + " monedas para cruzar.");
        return false;
    }

    public void jumpToNextLevel()
    {
        AddCoins(-progressionData.CoinsToNextLevel);
        progressionData.CurrentLevel++;
        progressionData.CoinsToNextLevel += 10;
    }

    private bool canCrossToNextLevel()
    {
        return progressionData.CurrentCoins >= progressionData.CoinsToNextLevel;
    }

}
