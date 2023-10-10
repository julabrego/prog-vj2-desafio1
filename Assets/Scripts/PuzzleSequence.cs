using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    [SerializeField] private int[] puzzleSequenceNumbers;
    private Queue<int> sequenceNumbers;
    [SerializeField] private Transform itemsToRestoreParent;

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

            if (isPuzzleSolved())
            {
                reenableAllCoins();
                InitializePuzzleSequence();
            }
        }
    }

    private bool isPuzzleSolved()
    {
        return sequenceNumbers.Count == 0;
    }

    private void reenableAllCoins()
    {
        foreach (Transform item in itemsToRestoreParent)
        {
            item.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            item.gameObject.SetActive(true);
        }
    }

}
