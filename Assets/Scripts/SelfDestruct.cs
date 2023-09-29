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
        InvokeRepeating(nameof(SelfDestruct), Duration, 1);
    }

    private void SelfDestruct()
    {
        Debug.Log("Destroyyy");
        //Destroy(gameObject);
    }
}
