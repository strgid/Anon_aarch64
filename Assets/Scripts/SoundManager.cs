using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager :BaseMonoManager<SoundManager>
{
    private AudioSource m_AudioSource;
    public AudioSource musicAudioSource;
    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(string ResourcePath, float volume = 1f)
    {
        AudioClip clip = Resources.Load<AudioClip>(ResourcePath);
        PlaySound(clip, volume);
    }
    public void PlaySound(AudioClip clip,float volume = 1f)
    {
        m_AudioSource.PlayOneShot(clip,volume);
    }
    public void MuteMusic()
    {
        musicAudioSource.mute = true;
    }
}
