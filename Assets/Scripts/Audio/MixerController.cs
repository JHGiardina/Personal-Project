using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void SetMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVFXVolume(float sliderValue)
    {
        audioMixer.SetFloat("PickupVolume", Mathf.Log10(sliderValue) * 20);
        audioMixer.SetFloat("PlayerVolume", Mathf.Log10(sliderValue) * 20);

    }
}
