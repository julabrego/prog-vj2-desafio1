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

    [SerializeField]
    [Tooltip("Sonido de daño")]
    private AudioClip hitSFX;

    [SerializeField]
    [Tooltip("Sonido de Click")]
    private AudioClip clickSFX;

    [SerializeField]
    [Tooltip("Sonido de Puzzle resuelto")]
    private AudioClip puzzleSolvedSFX;

    [SerializeField]
    [Tooltip("Sonido de Game Over")]
    private AudioClip gameOverSFX;

    [SerializeField]
    [Tooltip("Sonido de victoria")]
    private AudioClip victorySFX;

    private AudioSource myAudioSource;

    private Game game;
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCollider;

    private bool isInvincible = false;

    private void OnEnable()
    {
        GameEvents.OnOpenNextLevel += playClickSFX;
        GameEvents.OnPuzzleSolved += playPuzzleSolvedSFX;
        GameEvents.OnGameOver += playGameOverSFX;
        GameEvents.OnVictory += playVictorySFX;
    }

    private void OnDisable()
    {
        GameEvents.OnOpenNextLevel -= playClickSFX;
        GameEvents.OnPuzzleSolved -= playPuzzleSolvedSFX;
        GameEvents.OnGameOver -= playGameOverSFX;
        GameEvents.OnVictory -= playVictorySFX;
    }

    private void Start()
    {
        game = FindObjectOfType<Game>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CircleCollider2D>();
        myAudioSource = GetComponent<AudioSource>();
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
            myAudioSource.PlayOneShot(hitSFX);
            if (game.Playing) StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private void makeInvisible()
    {
        myCollider.enabled = false;
    }

    private void playClickSFX()
    {
        myAudioSource.PlayOneShot(clickSFX);
    }

    private void playPuzzleSolvedSFX()
    {
        myAudioSource.PlayOneShot(puzzleSolvedSFX);
    }

    private void playGameOverSFX()
    {
        myAudioSource.PlayOneShot(gameOverSFX);
    }

    private void playVictorySFX()
    {
        myAudioSource.PlayOneShot(victorySFX);
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
