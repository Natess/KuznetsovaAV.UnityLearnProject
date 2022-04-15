using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer _mixer;
 
    public void SetVolumeLevel(float volume)
    {
        _mixer.SetFloat("SoundsSetting", volume);
    }
}
