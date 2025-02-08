using UnityEngine;

public class RhythmDetector : MonoBehaviour
{
    private bool hasEntered = false;
    private RhythmInteraction rhythmInteractor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rhythmInteractor = GetComponentInParent<RhythmInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            Debug.Log("Player has entered trigger zone");
            rhythmInteractor.enabled = true;

            ChangeAmbienceVolume.instance.LowerVolume();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && hasEntered)
        {
            hasEntered = false;
            Debug.Log("Player has left trigger zone");
            rhythmInteractor.enabled = false;

            ChangeAmbienceVolume.instance.ReturnOriginalVolume();
        }
    }
}
