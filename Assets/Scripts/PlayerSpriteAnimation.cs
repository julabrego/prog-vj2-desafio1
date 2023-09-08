using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    // Variable para referenciar otro componente del objeto
    private Animator miAnimator;
    private Mover movimiento;

    private void OnEnable()
    {
        miAnimator = GetComponent<Animator>();
        movimiento = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedWalking = Mathf.Abs(movimiento.getVelocity().x) + Mathf.Abs(movimiento.getVelocity().y);
        Debug.Log(speedWalking);
        miAnimator.SetFloat("Speed", speedWalking);
        miAnimator.SetFloat("Horizontal", movimiento.getVelocity().x);
        miAnimator.SetFloat("Vertical", movimiento.getVelocity().y);

        miAnimator.gameObject.GetComponent<Animator>().enabled = speedWalking != 0;
    }
}
