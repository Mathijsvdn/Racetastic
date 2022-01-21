using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI masterText, sfxText, musicText;
    public Slider masterSlider, sfxSlider, musicSlider;
    public TMP_Dropdown qualityDropdown;
    public AudioMixer mixer;
    public float offset;
    private string masterString, sfxString, musicString;

    private void Start()
    {
        masterString = masterText.text;
        sfxString = sfxText.text;
        musicString = musicText.text;

        masterSlider.value = PlayerPrefs.GetFloat("Master Slider");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Slider");
        musicSlider.value = PlayerPrefs.GetFloat("Music Slider");

        qualityDropdown.value = PlayerPrefs.GetInt("Quality Index");
    }

    public void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("Master Slider", masterSlider.value);

        mixer.SetFloat("Master", volume);
        volume += offset;
        masterText.text = masterString + volume.ToString("f0") + "%";
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX Slider", sfxSlider.value);

        mixer.SetFloat("SFX", volume);
        volume += offset;
        sfxText.text = sfxString + volume.ToString("f0") + "%";
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("Music Slider", musicSlider.value);

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
        PlayerPrefs.SetInt("Quality Index", qualityIndex);

        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
