using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private bool joystickEnabled = false;

    private int totalLevelCoins;
    private int collectedCoins = 0;
    public int TotalLevelCoins { get => totalLevelCoins; set => totalLevelCoins = value; }
    public bool JoystickEnabled { get => joystickEnabled; set => joystickEnabled = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int _coins)
    {
        collectedCoins += _coins;
        Debug.Log("Monedas: " + collectedCoins);
        Debug.Log("Restantes: " + TotalLevelCoins);

        if(collectedCoins >= totalLevelCoins)
        {
            win();
        }
    }

    public int getCollectedCoins()
    {
        return collectedCoins;
    }

    public void win()
    {
        joystickEnabled = false;
        Debug.LogWarning("GANASTE (Recolectaste todas las monedas)");
    }
    public void lose()
    {
        joystickEnabled = false;
        Debug.LogWarning("PERDISTE (Tu personaje se quedó sin vida)");
    }
}
