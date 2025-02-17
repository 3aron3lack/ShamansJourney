using UnityEngine;
using UnityEngine.Audio;

public class AudioOptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer ambientMixer;
    [SerializeField] AudioMixer soundMixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // -- BUG: When changing scene the volume is correctly changed, but the slide position not. --
    public void OnMusicSlider(float musicVolume)
    {
        musicMixer.SetFloat("Volume", Mathf.Log10(musicVolume) * 20);
        AudioMixerVolumeOptions.musicVolume = musicVolume;
    }
    public void OnAmbientSlider(float ambientVolume)
    {
        ambientMixer.SetFloat("Volume", Mathf.Log10(ambientVolume) * 20);
        AudioMixerVolumeOptions.ambientVolume = ambientVolume;
    }
    public void OnSoundSlider(float soundVolume)
    {
        soundMixer.SetFloat("Volume", Mathf.Log10(soundVolume) * 20);
        AudioMixerVolumeOptions.soundVolume = soundVolume;
    }

    //public void OnMusicSlider(float musicVolume)
    //{
    //    musicMixer.SetFloat("Volume", Mathf.Log10(musicVolume) * 20);
    //}
    //public void OnAmbientSlider(float ambientVolume)
    //{
    //    ambientMixer.SetFloat("Volume", Mathf.Log10(ambientVolume) * 20);
    //}
    //public void OnSoundSlider(float soundVolume)
    //{
    //    soundMixer.SetFloat("Volume", Mathf.Log10(soundVolume) * 20);
    //}


}
