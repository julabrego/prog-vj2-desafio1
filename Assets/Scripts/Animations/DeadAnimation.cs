using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour
{
    // Variable para referenciar otro componente del objeto
    private Animator miAnimator;

    private string DEAD_PARAM = "Dead", ALWAYS_PLAY_ANIMATION_PARAM = "AlwaysPlayAnimation";

    private void OnEnable()
    {
        miAnimator = gameObject.GetComponent<Animator>();
        GameEvents.OnGameOver += playDeadAnimation;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= playDeadAnimation;
    }

    private void Update()
    {
        if (miAnimator.GetBool(DEAD_PARAM)) miAnimator.gameObject.GetComponent<Animator>().speed = 1;
    }

    public void playDeadAnimation()
    {
        miAnimator.SetBool(DEAD_PARAM, true);
        miAnimator.SetBool(ALWAYS_PLAY_ANIMATION_PARAM, true);
        Debug.Log("Se morista");
    }
}
