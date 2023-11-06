using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle soundFxToggle;
    [SerializeField] private Toggle musicToggle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPersistedValues();
    }

    public void LoadPersistedValues()
    {
        Debug.Log("Reloaded");
        volumeSlider.value = PersistenceManager.Instance.GetFloat(GameManager.Instance.PersistenceKeys.VolumeKey);
        soundFxToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.SoundFXKey);
        musicToggle.isOn = PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.MusicKey);
    }
}
