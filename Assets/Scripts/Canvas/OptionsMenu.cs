using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer music;
    [SerializeField]
    private AudioMixer soundEffects;

    public void ChangeMusicVolume(float volume)
    {
        music.SetFloat("Music", volume);
    }

    public void ChangeEffectsSoundVolume(float volume)
    {
        soundEffects.SetFloat("SoundEffects", volume);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
