using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private float moverVertical;
    private Vector2 direccion;
    private Game game;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        if (game.JoystickEnabled)
        {
            moverHorizontal = Input.GetAxis("Horizontal");
            moverVertical = Input.GetAxis("Vertical");
        }

        direccion = new Vector2(moverHorizontal, moverVertical);
    }
    private void FixedUpdate()
    {
        myRigidbody2D.MovePosition(myRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
    }
}