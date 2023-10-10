using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePosition : MonoBehaviour
{
    [SerializeField] private int position;

    public int Position { get => position; set => position = value; }
}
