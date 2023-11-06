using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePersonAnimation : MonoBehaviour
{
    protected string SPEED_PARAM = "Speed", HORIZONTAL_PARAM = "Horizontal",
        VERTICAL_PARAM = "Vertical", ALWAYS_PLAY_ANIMATION_PARAM = "AlwaysPlayAnimation";

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

        miAnimator.SetFloat(SPEED_PARAM, speedWalking);
        miAnimator.SetFloat(HORIZONTAL_PARAM, getVelocity().x);
        miAnimator.SetFloat(VERTICAL_PARAM, getVelocity().y);

        if (miAnimator.GetBool(ALWAYS_PLAY_ANIMATION_PARAM))
        {
            miAnimator.gameObject.GetComponent<Animator>().speed = 1;
        }
        else
        {
            miAnimator.gameObject.GetComponent<Animator>().speed = speedWalking != 0 ? 1 : 0 ;
        }
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
