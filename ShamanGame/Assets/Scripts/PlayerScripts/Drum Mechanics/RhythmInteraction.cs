using UnityEngine;

public class RhythmInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private AudioSource audioSource;
    [SerializeField] private AudioSource notificationSource;
    [SerializeField] private AudioClip rhythmClip;
    [SerializeField] private AudioClip failClip;
    [SerializeField] private AudioClip successClip;

    [SerializeField] private int rhythmInitLength = 3;
    public int playerInputCount = 0;

    public PlayerDrumMechanic playerDrums;

    public float rhythmTimer = 0;
    public float bpm = 120;
    public float deviationBpm = 0.3f;
    public float inactionTimer = 0;
    public float maxInactionTime = 3f;

    public bool rhythmIsPlaying = true;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDrumBoolCount();
        RhythmTimer();  
    }

    private void PlayerDrumBoolCount()
    {
        if(playerInputCount >= rhythmInitLength) 
        {
            Debug.Log("Initiate Mechanic!");
            notificationSource.PlayOneShot(successClip);
            playerInputCount = 0;
            rhythmIsPlaying = false;
        }

        if(playerDrums.drumCounter == true)
        {            
            if(rhythmTimer <= 0 + deviationBpm || rhythmTimer >= 60/bpm - deviationBpm)
            {
                playerInputCount++;
                Debug.Log("current time is: " + rhythmTimer);                       
            }
            else
            {
                notificationSource.PlayOneShot(failClip);
                Debug.Log("current time is: " + rhythmTimer);
                playerInputCount = 0;
            }
            Debug.Log("playerInputCount is: " + playerInputCount);

        }
        // This is real dirty. Maybe I can uncouple it?   
        playerDrums.drumCounter = false;
    }

    private void RhythmTimer()
    {
        if(rhythmIsPlaying)
        {
            rhythmTimer += Time.deltaTime;
            if (rhythmTimer > 60 / bpm)
            {
                audioSource.PlayOneShot(rhythmClip);
                rhythmTimer = 0;
                
            }

            if(playerInputCount > 0)
            {
                inactionTimer += Time.deltaTime;
                if (inactionTimer > maxInactionTime)
                {
                    inactionTimer = 0;
                    playerInputCount = 0;
                    Debug.Log("Max Inaction Time reached");
                }
            }           
        }
    }
 

    private void OnDisable()
    {
        playerInputCount = 0;
        rhythmTimer = 0;
        inactionTimer = 0;
        rhythmIsPlaying = true;
    }
}
