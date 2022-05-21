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

        PlaySound("theme", true, false);
    }

    public AudioSource PlaySound(string soundName, bool playOnAwake = true, bool DestroyOnCompletion = true)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);
        if (sound == null)
        {
            Debug.LogError("Sound " + soundName + " not found!");
        }
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = sound.loop;
        audioSource.volume = sound.defualtVolume;
        audioSource.pitch = sound.defualtPitch;
        audioSource.clip = sound.audioClip;
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
