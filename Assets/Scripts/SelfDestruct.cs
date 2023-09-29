using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeltDestruct : MonoBehaviour
{
    
    private float duration;

    public float Duration { get => duration; set => duration = value; }

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SelfDestruct), Duration);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
