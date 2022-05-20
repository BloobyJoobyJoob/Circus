using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public AudioClip audioClip;
    public string name;
    [Range(0, 1)]
    public float defualtVolume;
    [Range(0, 3)]
    public float defualtPitch;
    public bool loop;
}
