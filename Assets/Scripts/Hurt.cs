using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    private Game game;
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float puntos = 5f;
    private void Start()
    {
        game = FindObjectOfType<Game>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player jugador = collision.gameObject.GetComponent<Player>();

            if (jugador.isAlive())
            {
                jugador.ModificarVida(-puntos);
                Debug.Log(" VIDA: " + collision.gameObject.GetComponent<Player>().Vida);
            }
        }
    }
}