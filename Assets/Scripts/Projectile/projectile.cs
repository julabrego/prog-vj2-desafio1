using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        CalculateDirection();
        Move();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    protected abstract void Move();
    protected abstract void CalculateDirection();

}