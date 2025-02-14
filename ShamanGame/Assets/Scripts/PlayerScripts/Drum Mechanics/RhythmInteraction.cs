using UnityEngine;
using UnityEngine.Events;

public class RhythmInteraction : MonoBehaviour
{
    private RhythmMaterialLerp rhythmMaterialLerp;

    [SerializeField] private UnityEvent OnInteractionEnd;

    [Header("Audio Settings")]
    
    [SerializeField] private AudioSource notificationSource;
    [SerializeField] private AudioClip rhythmClip;
    [SerializeField] private AudioClip failClip;
    [SerializeField] private AudioClip successClip;
    private AudioSource audioSource;

    [Header("Rhythm and Timer Settings")]
    [SerializeField] private int rhythmInitLength = 3;
    private float rhythmTimer = 0;
    //public float bpm = 120;
    public float deviationBpm = 0.3f;

    //public int playerInputCount = 0;

    public float[] timeBetweenBeat;
    private int currentTBB = 0;

    

    public bool rhythmIsPlaying = true;

    [Header("Player Settings")]
    public PlayerDrumMechanic playerDrums;

    public int playerInputCount = 0;
    private float inactionTimer = 0;

    public float maxInactionTime = 0.2f;
    public int currentInaction;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rhythmMaterialLerp = GetComponent<RhythmMaterialLerp>();
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
            //Debug.Log("Initiate Mechanic!");
            notificationSource.PlayOneShot(successClip);

            //rhythmMaterialLerp.FinishedMaterial();
            OnInteractionEnd.Invoke();
            

            playerInputCount = 0;
            rhythmIsPlaying = false;
        }

        //if(playerDrums.drumCounter == true)
        //{            
        //    if(rhythmTimer <= 0 + deviationBpm || rhythmTimer >= 60/bpm - deviationBpm)
        //    {
        //        rhythmMaterialLerp.LerpToEmissionCol();
        //        playerInputCount++;
        //        Debug.Log("current time is: " + rhythmTimer);
                
        //        if(playerInputCount >= rhythmInitLength)
        //        {
        //            // The line below sometimes stops in the middle of the transition. Maybe the timer is at fault?
        //            rhythmMaterialLerp.BlinkOnEnd();
        //        }
        //        else
        //        rhythmMaterialLerp.BlinkOnBeat();
        //    }
        //    else
        //    {
        //        notificationSource.PlayOneShot(failClip);               
        //        Debug.Log("current time is: " + rhythmTimer);
        //        playerInputCount = 0;
        //    }
        //    Debug.Log("playerInputCount is: " + playerInputCount);
        //}

        // -- New Method --

        if(playerDrums.drumCounter == true)
        {
            if(rhythmTimer <= 0 + deviationBpm || rhythmTimer >= timeBetweenBeat[currentTBB] -  deviationBpm)
            {
                rhythmMaterialLerp.LerpToEmissionCol();
                playerInputCount++;
               // Debug.Log("current time is: " + rhythmTimer);

                if (playerInputCount >= rhythmInitLength)
                {
                    // The line below sometimes stops in the middle of the transition. Maybe the timer is at fault?
                    rhythmMaterialLerp.BlinkOnEnd();
                }
                else
                    rhythmMaterialLerp.BlinkOnBeat();
            }
            else
            {
                notificationSource.PlayOneShot(failClip);
                //Debug.Log("current time is: " + rhythmTimer);
                playerInputCount = 0;
            }
            Debug.Log("playerInputCount is: " + playerInputCount);
        
        }


        // This is real dirty. Maybe I can uncouple it?   
        playerDrums.drumCounter = false;
    }

    private void RhythmTimer()
    {
        //if(rhythmIsPlaying)
        //{
        //    rhythmTimer += Time.deltaTime;
        //    if (rhythmTimer > 60 / bpm)
        //    {
        //        audioSource.PlayOneShot(rhythmClip);
        //        rhythmTimer = 0;
                
        //    }

        //    if(playerInputCount > 0)
        //    {
        //        inactionTimer += Time.deltaTime;
        //        if (inactionTimer > maxInactionTime)
        //        {
        //            inactionTimer = 0;
        //            playerInputCount = 0;
        //            Debug.Log("Max Inaction Time reached");
        //        }
        //    }           
        //}

        // -- New Mehtod --
        if (rhythmIsPlaying)
        {
            rhythmTimer += Time.deltaTime;
            //Debug.Log("rhytmTimer is: " + rhythmTimer);
            if(rhythmTimer > timeBetweenBeat[currentTBB])
            {
                audioSource.PlayOneShot(rhythmClip);
                rhythmTimer = 0;
                //Debug.Log("rhytmTimer reset");
                currentTBB++;
                if(currentTBB >= timeBetweenBeat.Length)
                {
                    currentTBB = 0;
                }
            }

            if (playerInputCount > 0)
            {
                inactionTimer += Time.deltaTime;

                currentInaction = currentTBB + 1;
                if (currentInaction >= rhythmInitLength)
                {
                    currentInaction = 0;
                }

                Debug.Log("inactionTimer is: " + inactionTimer);
                if (inactionTimer > timeBetweenBeat[currentInaction])
                {
                    inactionTimer = 0;
                    Debug.Log("inactionTimer reset");
                    playerInputCount = 0;
                    //Debug.Log("Max Inaction Time reached");
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
