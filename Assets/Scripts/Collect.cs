using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour 
{
    [SerializeField] private AudioClip coinSFX;

    private AudioSource myAudioSource;
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myCollider;
    private bool isCollected = false;
    private ParticleSystem myParticleSystem;
    private Game game;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnEnable()
    {
        myAudioSource = GetComponent<AudioSource>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            Player jugador = collision.gameObject.GetComponent<Player>();
            game.AddCoins(1);

            mySpriteRenderer.enabled = false;
            myCollider.enabled = false;
            myAudioSource.PlayOneShot(coinSFX);
            myParticleSystem.Play();
        }
    }

    private void Update()
    {
        if (!myAudioSource.isPlaying && isCollected) gameObject.SetActive(false);
    }
}
