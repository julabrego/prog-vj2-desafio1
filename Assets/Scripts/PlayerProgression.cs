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
    [SerializeField] UnityEvent<int> OnLivesChanged;
    [SerializeField] UnityEvent<bool> OnEndGameTriggered;

    private void OnEnable()
    {
        GameEvents.OnVictory += win;
        GameEvents.OnGameOver += lose;
    }

    private void OnDisable()
    {
        GameEvents.OnVictory -= win;
        GameEvents.OnGameOver -= lose;
    }

    private void Start()
    {
        progressionData.CurrentLevel = 0;
        progressionData.CurrentCoins = 0;
        progressionData.CoinsToNextLevel = 10;
        progressionData.Health = 5;

        OnCoinsTextChanged.Invoke(getCurrentCoins().ToString());
        OnLivesChanged.Invoke(progressionData.Health);
    }

    public void UpdateHealth(int puntos)
    {
        progressionData.Health += puntos;
        OnLivesChanged.Invoke(progressionData.Health);
        
        if (progressionData.Health <= 0)
        {
            GameEvents.TriggerGameOver();
        }
    }

    public bool isAlive()
    {
        return progressionData.Health > 0;
    }
    public void AddCoins(int _coins)
    {
        progressionData.CurrentCoins += _coins;
        GameManager.Instance.AddScore(_coins * 10);
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

    public void win()
    {
        OnEndGameTriggered.Invoke(true);
    }
    public void lose()
    {
        OnEndGameTriggered.Invoke(false);
    }

    private bool canCrossToNextLevel()
    {
        return progressionData.CurrentCoins >= progressionData.CoinsToNextLevel;
    }

}
