using System.Security;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 100f)]
    public float volume;

    [Range(0.1f, 2f)]
    public float pitchMax;
    [Range(0.1f, 2f)]
    public float pitchMin;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
