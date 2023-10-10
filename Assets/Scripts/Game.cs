using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private PlayerProgression playerProgression;

    private bool joystickEnabled = false;
    private bool playing = true;

    public bool JoystickEnabled { get => joystickEnabled; set => joystickEnabled = value; }
    public bool Playing { get => playing; set => playing = value; }

    private void Start()
    {
        playerProgression = gameObject.GetComponent<PlayerProgression>();
    }
    public void AddCoins(int _coins)
    {
        playerProgression.AddCoins(_coins);
    }

    public int getCollectedCoins()
    {
        return playerProgression.getCurrentCoins();
    }

    public void win()
    {
        joystickEnabled = Playing = false;
        Debug.LogWarning("GANASTE (Llegaste a la bandera)");
    }
    public void lose()
    {
        joystickEnabled = Playing = false;
        Debug.LogWarning("PERDISTE (Tu personaje se quedó sin vida)");
    }
}
