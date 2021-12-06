using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI masterText, sfxText, musicText;
    public AudioMixer mixer;
    public float offset, defaultVolume;
    private string masterString, sfxString, musicString;

    private void Start()
    {
        masterString = masterText.text;
        sfxString = sfxText.text;
        musicString = musicText.text;
        SetMasterVolume(defaultVolume);
        SetSFXVolume(defaultVolume);
        SetMusicVolume(defaultVolume);
    }

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("Master", volume);
        volume += offset;
        masterText.text = masterString + volume.ToString("f0") + "%";
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFX", volume);

        volume += offset;
        sfxText.text = sfxString + volume.ToString("f0") + "%";
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("Music", volume);

        volume += offset;
        musicText.text = musicString + volume.ToString("f0") + "%";
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
