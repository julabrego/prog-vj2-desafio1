using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicConfiguration : AbstractAudioConfiguration
{
     public override void LoadStatus()
    {
        gameObject.GetComponent<AudioSource>().mute = !PersistenceManager.Instance.GetBool(GameManager.Instance.PersistenceKeys.MusicKey);
    }
}
