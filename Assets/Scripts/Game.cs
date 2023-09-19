using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private bool joystickEnabled = false;
    private bool playing = true;

    private int totalLevelCoins;
    private int collectedCoins = 0;
    public int TotalLevelCoins { get => totalLevelCoins; set => totalLevelCoins = value; }
    public bool JoystickEnabled { get => joystickEnabled; set => joystickEnabled = value; }
    public bool Playing { get => playing; set => playing = value; }

    public void AddCoins(int _coins)
    {
        collectedCoins += _coins;
        Debug.Log("Monedas: " + collectedCoins);

        if(collectedCoins >= totalLevelCoins)
            win();
    }

    public int getCollectedCoins()
    {
        return collectedCoins;
    }

    public void win()
    {
        joystickEnabled = Playing = false;
        Debug.LogWarning("GANASTE (Recolectaste todas las monedas)");
    }
    public void lose()
    {
        joystickEnabled = Playing = false;
        Debug.LogWarning("PERDISTE (Tu personaje se quedó sin vida)");
    }
}
