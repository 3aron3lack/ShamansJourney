using UnityEngine;

public class PlaySoundclip : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(clip);
    }
}
