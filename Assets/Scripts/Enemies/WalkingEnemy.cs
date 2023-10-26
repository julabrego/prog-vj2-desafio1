using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WalkingEnemy : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] protected float speed = 5f;
    
    protected Vector2 direction;
    protected Rigidbody2D rigidBody2D;

    public abstract void Walk();

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Walk();
    }

}
