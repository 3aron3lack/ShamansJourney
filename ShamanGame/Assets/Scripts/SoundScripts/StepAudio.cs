using UnityEngine;

public class StepAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private LayerMask rockLayer;
    private LayerMask grassLayer;
    private LayerMask woodLayer;

    [SerializeField] AudioClip[] rockStepClips;
    [SerializeField] AudioClip[] grassStepClips;
    [SerializeField] AudioClip[] woodStepClips;

    private AudioClip currentClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grassLayer = LayerMask.GetMask("Grass");
        rockLayer = LayerMask.GetMask("Rock");
        woodLayer = LayerMask.GetMask("Wood");
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
        else if(Physics.Raycast(transform.position, -transform.up, 2f, woodLayer))
        {
            currentClip = woodStepClips[Random.Range(0, woodStepClips.Length)];
            audioSource.PlayOneShot(currentClip);
        }
        else
        {
            currentClip = rockStepClips[Random.Range(0, rockStepClips.Length)];
            audioSource.PlayOneShot(currentClip);
        }
    }
}
