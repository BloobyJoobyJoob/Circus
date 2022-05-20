using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public AudioSource PlaySound(string soundName, bool playOnAwake = true, bool DestroyOnCompletion = true)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);

        AudioSource audioSource = new AudioSource();
        audioSource.loop = sound.loop; 
        if (playOnAwake)
        {
            audioSource.Play();
            if (DestroyOnCompletion)
            {
                Destroy(audioSource, sound.audioClip.length * sound.defualtPitch);
            }
        }
        return audioSource;
    }
}
