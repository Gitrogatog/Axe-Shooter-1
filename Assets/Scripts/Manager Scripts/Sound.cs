using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range (0f, 1f)]
    public float volume;
    [Range (0.1f, 3f)]
    public float pitch;
    [Range (0, 0.2f)]
    public float randPitch = 0;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
