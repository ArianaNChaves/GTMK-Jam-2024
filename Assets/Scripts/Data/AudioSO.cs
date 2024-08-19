using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Audio Data", menuName = "ScriptableObjects/Audio Data")]
public class AudioSO : ScriptableObject
{
    [SerializeField] private float musicvolume;
    [SerializeField] private float SFXvolume;
    
    private float _globalVolume;
    
    
    public void SetMusicVolume(float volume)
    {
        musicvolume = volume;
    }
    
    public void SetSFXVolume(float volume)
    {
        SFXvolume = volume;
    }

    public float GetMusicVolume()
    {
        return musicvolume;
    }
    public float GetSFXVolume()
    {
        return SFXvolume;
    }
    
}
