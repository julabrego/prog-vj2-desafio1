using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Referencia al transform del jugador serializada
    [SerializeField] Transform jugador;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    // Animación
    private Animator miAnimator;
    private SpriteRenderer miSprite;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        direccion = (jugador.position - transform.position).normalized;
        if (Vector2.Distance(jugador.position, transform.position) < 5)
        {
            miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
            miAnimator.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            miAnimator.gameObject.GetComponent<Animator>().enabled = false;
        }

        miAnimator.SetFloat("Horizontal", direccion.x);
        miAnimator.SetFloat("Vertical", direccion.y);
        
    }

}