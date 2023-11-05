using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : WalkingEnemy
{
    [Header("Configuracion")]
    [SerializeField] float distanceRange = 3f;
    [SerializeField] float startDirection = 1f;

    private Vector2 startPosition;

    public override void Walk()
    {
        if (Vector2.Distance(startPosition, transform.position) > distanceRange)
            reverseDirection();

        rigidBody2D.MovePosition(rigidBody2D.position + direction * (speed * Time.fixedDeltaTime));
    }

    private void Awake()
    {
        startPosition = transform.position;
        direction = new Vector2(startDirection, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        reverseDirection();
    }

    private void reverseDirection()
    {
        startDirection *= -1;
        direction = new Vector2(startDirection, 0f);
    }
}