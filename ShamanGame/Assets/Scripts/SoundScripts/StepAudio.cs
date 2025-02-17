using UnityEngine;

public class StepAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private LayerMask rockLayer;
    private LayerMask grassLayer;

    [SerializeField] AudioClip[] rockStepClips;
    [SerializeField] AudioClip[] grassStepClips;

    private AudioClip currentClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grassLayer = LayerMask.GetMask("Grass");
        rockLayer = LayerMask.GetMask("Rock");
    }

    void PlayStepAudio()
    {
        if(Physics.Raycast(transform.position, -transform.up, 2f, rockLayer))
        {
            currentClip = rockStepClips[Random.Range(0, rockStepClips.Length)];
            audioSource.PlayOneShot(currentClip);
        }
        else if(Physics.Raycast(transform.position, -transform.up, 2f, grassLayer))
        {
            currentClip = grassStepClips[Random.Range(0, grassStepClips.Length)];
            audioSource.PlayOneShot(currentClip);
        }
        else
        {
            currentClip = rockStepClips[Random.Range(0, rockStepClips.Length)];
            audioSource.PlayOneShot(currentClip);
        }
    }
}
