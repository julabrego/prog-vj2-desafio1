using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : WalkingEnemy
{
    [Header("Configuracion")]
    [SerializeField] private Transform target;

    public Transform Target { private get => target; set => target = value; }

    public override void Walk()
    {
        direction = (target.position - transform.position).normalized;
        followTarget();
    }

    public void SetSpeed(int _speed)
    {
        speed = _speed;
    }

    private void followTarget()
    {
        if (Vector2.Distance(Target.position, transform.position) < 5)
            rigidBody2D.MovePosition(rigidBody2D.position + direction * (speed * Time.fixedDeltaTime));
    }
}