using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] UnityEvent<int> OnPlayerReceivesDamage;
    [SerializeField]
    [Range(0, 5)]
    [Tooltip("Tiempo en segundos en que el presonaje permanece invencible tras sufrir daño")]
    private float invincibilityDuration = 2;

    [SerializeField]
    [Range(0, 1)]
    [Tooltip("Delta time para manejar velocidad de invincible frames (parpadeo)")]
    private float invincibilityDeltaTime = 0.12f;

    private Game game;
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCollider;

    private bool isInvincible = false;

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
        if (!isInvincible)
        {
            OnPlayerReceivesDamage.Invoke(-points);
            if(game.Playing) StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private void makeInvisible()
    {
        myCollider.enabled = false;
        //mySpriteRenderer.enabled = false;
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        Debug.Log("Invincible");

        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
            if (mySpriteRenderer.enabled)
            {
                mySpriteRenderer.enabled = false;
            }
            else
            {
                mySpriteRenderer.enabled = true;
            }
        }

        isInvincible = false;
        mySpriteRenderer.enabled = true;
    }

}
