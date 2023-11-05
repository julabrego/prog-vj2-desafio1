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
        volumeSlider.value = PersistenceManager.Instance.GetFloat(GameManager.Instance.PersistenceKeys.VolumeKey);
        soundFxToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.SoundFXKey);
        musicToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.MusicKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
