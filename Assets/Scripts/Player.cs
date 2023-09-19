using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

    private Game game;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }
    public float Vida { get => vida; set => vida = value; }

    public void ModificarVida(float puntos)
    {
        Vida += puntos;
        if(Vida <= 0)
            game.lose();
    }

    public bool isAlive()
    {
        return Vida > 0;
    }

}
