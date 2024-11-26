using UnityEngine;

public class DrumSounds : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip TapSound;
    [SerializeField] private AudioClip BeatSound;
    [SerializeField] private AudioClip CorrectSound;
    [SerializeField] private AudioClip ErrorSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(audioSource);
    }

    public void PlayTap()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(TapSound);
        }
    }

    public void PlayBeat()
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(BeatSound);
        }
    }

    public void PlayCorrect()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(CorrectSound);
        }
    }

    public void PlayError()
    {
        if(audioSource != null) 
        { 
            audioSource.PlayOneShot(ErrorSound);      
        }
    }

}
