using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Game game;
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCollider;

    [SerializeField] UnityEvent<int> OnPlayerReceivesDamage;

    private void Start()
    {
        game = FindObjectOfType<Game>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CircleCollider2D>();
    }

    public void FixedUpdate()
    {
        if (!game.Playing && mySpriteRenderer.enabled)
            makeInvisible();
    }

    public void ReceiveDamage(int points)
    {
        OnPlayerReceivesDamage.Invoke(-points);
    }

    private void makeInvisible()
    {
        myCollider.enabled = false;
        mySpriteRenderer.enabled = false;
    }

}
