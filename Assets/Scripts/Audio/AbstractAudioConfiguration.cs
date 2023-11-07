using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAudioConfiguration : MonoBehaviour
{
    void Start()
    {
        LoadStatus();
        LoadVolume();
    }

    public void LoadVolume()
    {
        gameObject.GetComponent<AudioSource>().volume = PersistenceManager.Instance.GetFloat(GameManager.Instance.PersistenceKeys.VolumeKey, 0.5f);
    }
    public abstract void LoadStatus();
}
