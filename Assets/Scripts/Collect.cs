using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player jugador = collision.gameObject.GetComponent<Player>();
            jugador.AddCoins(1);
            
            Debug.Log("Monedas: " + jugador.getCoins());
            
            Destroy(gameObject);
        }
    }
}
