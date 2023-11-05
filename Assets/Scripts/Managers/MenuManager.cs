using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle soundFxToggle;
    [SerializeField] private Toggle musicToggle;
    
    void Start()
    {
        volumeSlider.value = 0.5f;
        soundFxToggle.isOn = true;
        musicToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
