using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private int vida = 5;

    private Game game;
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCollider;

    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    private void Start()
    {
        game = FindObjectOfType<Game>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CircleCollider2D>();

        OnLivesChanged.Invoke(vida);
    }
    public int Vida { get => vida; set => vida = value; }

    public void FixedUpdate()
    {
        if (!game.Playing && mySpriteRenderer.enabled)
            makeInvisible();
    }
    public void ModificarVida(int puntos)
    {
        Vida += puntos;
        if (Vida <= 0)
        {
            game.lose();
        }
        else
        {
            Debug.Log(" VIDA: " + vida);
        }
    }

    public bool isAlive()
    {
        return Vida > 0;
    }

    private void makeInvisible()
    {
        myCollider.enabled = false;
        mySpriteRenderer.enabled = false;
    }

}
