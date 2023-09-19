using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    // Variable para referenciar otro componente del objeto
    private Animator miAnimator;
    private Rigidbody2D myRigidbody2D;

    // Trackeo de velocidad
    private Vector2 trackVelocity;
    private Vector2 lastPosition;

    private void OnEnable()
    {
        miAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedWalking = Mathf.Abs(getVelocity().x) + Mathf.Abs(getVelocity().y);
        
        miAnimator.SetFloat("Speed", speedWalking);
        miAnimator.SetFloat("Horizontal", getVelocity().x);
        miAnimator.SetFloat("Vertical", getVelocity().y);

        miAnimator.gameObject.GetComponent<Animator>().enabled = speedWalking != 0;
    }

    private void FixedUpdate()
    {
        calculateVelocity();
    }

    protected void calculateVelocity()
    {
        trackVelocity = (myRigidbody2D.position - lastPosition) * 50;
        lastPosition = myRigidbody2D.position;
    }

    public Vector2 getVelocity()
    {
        return trackVelocity;
    }
}
