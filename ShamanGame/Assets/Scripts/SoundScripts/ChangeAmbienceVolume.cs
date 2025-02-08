using Unity.VisualScripting;
using UnityEngine;

public class ChangeAmbienceVolume : MonoBehaviour
{
    public static ChangeAmbienceVolume instance { get; private set; }

    public AudioSource[] ambience;
    private float originalVolume;
    private float loweredVolume;

    private float timer = 0f;
    public float shiftVolumeTime = 1f;

    private bool isLowered = false;
    private bool isOriginal = false; 

    //public bool isEngaged = false;

    private void Awake()
    {
        if(instance != null & instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        originalVolume = ambience[ambience.Length - 1].volume;
        loweredVolume = ambience[ambience.Length - 1].volume / 4;
    }

    public void LowerVolume()
    {
        isOriginal = false;
        isLowered = true;        
    }

    public void ReturnOriginalVolume()
    {
        isOriginal = true;
        isLowered = false;       
    }
    
    void Update()
    {
        if(isLowered)
        {
            timer += Time.deltaTime;
            if(timer < shiftVolumeTime)
            {
                foreach (var ambience in ambience)
                {
                    ambience.volume = Mathf.Lerp(originalVolume, loweredVolume, timer);
                }
            }
            else if(timer >= shiftVolumeTime)
            {
                isLowered = false;
                timer = 0;
                foreach (var ambience in ambience)
                {
                    ambience.volume = loweredVolume;
                }
            }
        }

        if (isOriginal)
        {
            timer += Time.deltaTime;
            if(timer < shiftVolumeTime)
            {
                foreach (var ambience in ambience)
                {
                    ambience.volume = Mathf.Lerp(loweredVolume, originalVolume, timer);
                }
            }
            else if (timer >= shiftVolumeTime)
            {
                isOriginal = false;
                timer = 0;
                foreach (var ambience in ambience)
                {
                    ambience.volume = originalVolume;
                }
            }
        }

    }
}
