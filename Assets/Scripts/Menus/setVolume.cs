using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public static float sliderValue1 = 0.5f;
    public static float sliderValue2 = 0.5f;
    public Slider SL1;
    public Slider SL2;
    private void Start()
    {
        sliderValue1 = PlayerPrefs.GetFloat("Volume");
        sliderValue2 = PlayerPrefs.GetFloat("Volume2");
        SL1.value = sliderValue1;
        SL2.value = sliderValue2;
    }
    public void SetLevel(float sliderValue1)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue1) * 20);
        PlayerPrefs.SetFloat("Volume", sliderValue1);

    }
    public void SetLevel2(float sliderValue2)
    {
        mixer.SetFloat("Volume2", Mathf.Log10(sliderValue2) * 20);
        PlayerPrefs.SetFloat("Volume2", sliderValue2);
    }
   
}