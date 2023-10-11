using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLevel : MonoBehaviour
{
    private Game game;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) { return; }

        if (game.PlayerProgression.purchaseNewLevel())
            Destroy(gameObject);
    }
}
