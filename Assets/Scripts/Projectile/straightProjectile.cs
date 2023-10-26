using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : Projectile
{
    protected override void CalculateDirection()
    {
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        float directionX = Mathf.Cos(angle);
        float directionY = Mathf.Sin(angle);

        direction = new Vector2(directionX, directionY).normalized;
    }

    protected override void Move()
    {
        rb.velocity = direction * speed;
    }

}
