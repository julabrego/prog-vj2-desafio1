using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    protected float speed = 10f;
    protected Vector2 direction = Vector2.left;

    protected Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Obt�n el �ngulo de rotaci�n en radianes
        float anguloEnRadianes = transform.eulerAngles.z * Mathf.Deg2Rad;

        // Calcula los componentes x y y del vector de direcci�n usando funciones trigonom�tricas
        float direccionX = Mathf.Cos(anguloEnRadianes);
        float direccionY = Mathf.Sin(anguloEnRadianes);

        // Asigna la direcci�n en la que se mover� el objeto basado en la rotaci�n del transform
        direction = new Vector2(direccionX, direccionY).normalized;

        Move();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    protected abstract void Move();
}