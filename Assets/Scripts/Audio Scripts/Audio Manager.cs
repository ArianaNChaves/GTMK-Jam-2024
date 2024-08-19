using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
        
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public AudioSO audioSettings;

    private string _lastSong;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        MusicVolume(audioSettings.GetMusicVolume());
        SfxVolume(audioSettings.GetSFXVolume());
    }
    public void PlayMusic(string musicName)
    {
        Sound sound = Array.Find(musicSounds, x => x.soundName == musicName);
        if (sound == null)
        {
            Debug.LogError("Sound not found");
        }
        else
        {
            if (musicName == _lastSong) return;
            _lastSong = sound.soundName;
            musicSource.clip = sound.clip;
            musicSource.Play();
            
        }
    }
    public void PlayEffect(string effectName)
    {
        Sound effect = Array.Find(sfxSounds, x => x.soundName == effectName);
        if (effect == null)
        {
            Debug.LogError("Effect not found");
        }
        else
        {
            sfxSource.PlayOneShot(effect.clip);
        }
    }
    public void MusicVolume(float volume)
    {
        audioSettings.SetMusicVolume(volume);
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        audioSettings.SetSFXVolume(volume);
        sfxSource.volume = volume;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
