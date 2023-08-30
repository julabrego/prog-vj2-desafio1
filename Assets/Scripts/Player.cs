using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    [SerializeField] private int coins = 0;
    
    public void ModificarVida(float puntos)
    {
        vida += puntos;
    }

    public void AddCoins(int _coins)
    {
        coins += _coins;
    }

    public int getCoins()
    {
        return coins;
    }
}
