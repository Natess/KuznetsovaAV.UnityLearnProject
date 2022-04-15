using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StepSoundControl : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Step()
    {
        _source.PlayOneShot(_clip);
    }
}
