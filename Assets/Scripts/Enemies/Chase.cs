using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : WalkingEnemy
{
    [Header("Configuracion")]
    [SerializeField] private Transform target;

    private Vector2 direccion;

    private Animator miAnimator;

    public Transform Target { get => target; set => target = value; }

    public override void Walk()
    {
        direccion = (target.position - transform.position).normalized;
        followTarget();
    }

    public void SetSpeed(int _speed)
    {
        speed = _speed;
    }

    private void Awake()
    {
        miAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void followTarget()
    {
        if (Vector2.Distance(target.position, transform.position) < 5)
        {
            rigidBody2D.MovePosition(rigidBody2D.position + direccion * (speed * Time.fixedDeltaTime));
            miAnimator.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            miAnimator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}