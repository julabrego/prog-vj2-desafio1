using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Game game;
    private CircleCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        myCollider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.win();
        }
    }
}
