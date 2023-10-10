using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField] private PlayerProgressionData progressionData;

    public void AddCoins(int _coins)
    {
        progressionData.CurrentCoins += _coins;
        Debug.Log("Monedas: " + progressionData.CurrentCoins);
    }

    public int getCurrentCoins()
    {
        return progressionData.CurrentCoins;
    }

    public void purchaseNewLevel()
    {
        if(progressionData.CurrentCoins >= progressionData.CoinsToNextLevel)
        {
            jumpToNextLevel();
        }
    }

    public void jumpToNextLevel()
    {
        progressionData.CurrentLevel++;
        progressionData.CurrentCoins -= progressionData.CoinsToNextLevel;
        progressionData.CoinsToNextLevel += 10;
    }
}
