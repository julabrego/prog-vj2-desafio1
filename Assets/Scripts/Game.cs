using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private PlayerProgression playerProgression;

    private bool joystickEnabled = false;
    private bool playing = true;

    public bool JoystickEnabled { get => joystickEnabled; set => joystickEnabled = value; }
    public bool Playing { get => playing; set => playing = value; }
    public PlayerProgression PlayerProgression { get => playerProgression; set => playerProgression = value; }


    private void Start()
    {
        PlayerProgression = gameObject.GetComponent<PlayerProgression>();
        GameManager.Instance.ResetScore();
    }
    public void AddCoins(int _coins)
    {
        PlayerProgression.AddCoins(_coins);
    }

    public int getCollectedCoins()
    {
        return PlayerProgression.getCurrentCoins();
    }

    public void StopGame()
    {
        Playing = JoystickEnabled = false;
    }

    public void GoToMainMenu()
    {
        ApplicationManager.Instance.GoToPreviousScene();
    }
}
