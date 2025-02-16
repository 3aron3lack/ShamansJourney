using UnityEngine;

public class StepAudio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] AudioClip[] stepClips;
    private AudioClip currentClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayStepAudio()
    {
        currentClip = stepClips[Random.Range(0, stepClips.Length)];

        audioSource.PlayOneShot(currentClip);
    }
}
