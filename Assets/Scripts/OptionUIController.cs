using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionUIController : MonoBehaviour
{
    public AudioMixer mainMixer;

    [Header("UI")] public Slider masterSlider;
    public Slider backgroundSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        //Gets volume params from PlayerPrefs
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        backgroundSlider.value = PlayerPrefs.GetFloat("BackgroundVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
    }

    public void MasterSliderChanged(float sliderValue)
    {
        //o volume do mixer é logaritmico, para ajustar o valor do slider ao valor do mixer é necessária a conversão
        //nota: o valor minimo do slider n pode ser 0, tem de ser ligeiramente acima
        float volume = Mathf.Log10(sliderValue) * 20f;
        mainMixer.SetFloat("MasterVolume", volume);

        //Saves volume params to PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void BackgroundSliderChanged(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20f;
        mainMixer.SetFloat("BackgroundVolume", volume);
        
        PlayerPrefs.SetFloat("BackgroundVolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void SfxSliderChanged(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20f;
        mainMixer.SetFloat("SfxVolume", volume);
        
        PlayerPrefs.SetFloat("SfxVolume", sliderValue);
        PlayerPrefs.Save();
    }
}