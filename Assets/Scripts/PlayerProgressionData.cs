using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObjects/PlayerProgressionData", order = 1)]
public class PlayerProgressionData : ScriptableObject
{
    [SerializeField][Range(0, 3)]
    [Tooltip("Islas a las que el jugador tiene acceso")]
    private int currentLevel;

    [SerializeField]
    [Tooltip("Cantidad de monedas recolectadas")]
    private int currentCoins;

    [SerializeField]
    [Tooltip("Cantidad de monedas necesarias para acceder a la siguiente isla")]
    private int coinsToNextLevel;

    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int CurrentCoins { get => currentCoins; set => currentCoins = value; }
    public int CoinsToNextLevel { get => coinsToNextLevel; set => coinsToNextLevel = value; }
}
