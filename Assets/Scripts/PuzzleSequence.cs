using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> sequenceButtons;
    [SerializeField] private GameObject pressedButtons;

    private bool pressed = false;

    private void Awake()
    {
        sequenceButtons = new Queue<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("NumberSequence")) { return; }

        GameObject newPressed = collision.gameObject;
        newPressed.SetActive(false);

        sequenceButtons.Enqueue(newPressed);
        newPressed.transform.SetParent(pressedButtons.transform);
    }
}
