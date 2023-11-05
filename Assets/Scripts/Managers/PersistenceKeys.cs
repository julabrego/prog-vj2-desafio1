using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersistenceKeys", menuName = "ScriptableObjects/PersistanceKeys", order = 1)]
public class PersistenceKeys : ScriptableObject
{
    [Header("Persistance Keys")]
    [Tooltip("High Score key")]
    [SerializeField] private string highScoreKey = "HighScore";
        public string HighScoreKey { get => highScoreKey; private set => highScoreKey = value; }
}