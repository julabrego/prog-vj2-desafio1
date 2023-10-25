using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 100f;
    [SerializeField] float startDirection = 1f;

    // Variable para referenciar otro componente del objeto
    private Vector2 direccion;
    private Vector2 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        direccion = new Vector2(startDirection, 0f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, velocidad * Time.deltaTime);
    }

}