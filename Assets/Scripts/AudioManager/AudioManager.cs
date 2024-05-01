using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audSrc = gameObject.AddComponent<AudioSource>();
            sound.audSrc.clip = sound.clip;
            sound.audSrc.volume = sound.volume;
            sound.audSrc.loop = sound.isLoop;
        }
    }

    private void Start()
    {
       // Play("Theme");
    }


    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.audSrc.Play();
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.audSrc.Stop();
    }
}
