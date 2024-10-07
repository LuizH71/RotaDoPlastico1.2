using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public string name;

    public AudioClip Clip;
    public AudioMixerGroup Output;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;
    public int Priority;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
