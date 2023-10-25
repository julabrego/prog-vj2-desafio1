using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : Projectile
{

    protected override void Move()
    {
        // Aplica la velocidad al Rigidbody
        Debug.Log(direction);
        Debug.Log(speed);
        rb.velocity = direction * speed;
    }
}
