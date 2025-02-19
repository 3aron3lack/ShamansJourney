using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(clip);
    }
}
