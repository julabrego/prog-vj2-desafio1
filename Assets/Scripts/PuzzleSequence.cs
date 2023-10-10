using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    [SerializeField] private int[] puzzleSequenceNumbers;
    private Queue<int> sequenceNumbers;
    [SerializeField] private Transform targetParent;

    private bool pressed = false;

    private void Awake()
    {
        sequenceNumbers = new Queue<int>();
        InitializePuzzleSequence();
    }

    private void InitializePuzzleSequence()
    {
        foreach (int number in puzzleSequenceNumbers)
        {
            sequenceNumbers.Enqueue(number);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("NumberSequence")) { return; }

        if(collision.gameObject.GetComponent<PuzzlePosition>().Position == sequenceNumbers.Peek())
        {
            Animator newPressed = collision.gameObject.GetComponent<Animator>();
            newPressed.SetBool("pressed", true);
            sequenceNumbers.Dequeue();

            Debug.Log(isPuzzleSolved());
        }
    }

    private bool isPuzzleSolved()
    {
        return sequenceNumbers.Count == 0;
    }
}
