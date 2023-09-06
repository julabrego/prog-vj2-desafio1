using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;
    [SerializeField] float distanceRange = 3f;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private float startDirection;
    private Vector2 direccion;
    private Vector2 startPosition;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        startDirection = 1f;
        direccion = new Vector2(startDirection, 0f);
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(startPosition, transform.position) > distanceRange)
        {
            startDirection *= -1;
            direccion = new Vector2(startDirection, 0f);
        }

        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));

        float speedWalking = Mathf.Abs(miRigidbody2D.velocity.x) + Mathf.Abs(miRigidbody2D.velocity.y);

        miAnimator.SetFloat("Speed", speedWalking);
        miAnimator.SetFloat("Horizontal", direccion.x);
        miAnimator.SetFloat("Vertical", direccion.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        startDirection *= -1;
        direccion = new Vector2(startDirection, 0f);
    }

}