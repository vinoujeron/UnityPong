using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    int i = 1;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public Sound[] sounds;
    private AudioSource _audioSource;

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.name = sound.name;
        }
    }

    private void Update()
    {   // Tried here to implement loop from 4 songs in AudioSource
        
        if (!_audioSource.isPlaying)
        {
            if (i < 8)
            {
                _audioSource.PlayOneShot(audioClips[i]);
                i++;
            }
            else if (i < 16)
            {
                _audioSource.PlayOneShot(audioClips[i - 4]);
                i++;
            }
            else
            {
                i = 1;
                _audioSource.PlayOneShot(audioClips[i]);
            }
                
        }
    }

   public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
