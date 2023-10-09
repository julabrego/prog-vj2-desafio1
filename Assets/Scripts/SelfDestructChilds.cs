using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructChilds : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 5f)]
    private float childLifetime;

    public float ChildLifetime { get => childLifetime; set => childLifetime = value; }
}
