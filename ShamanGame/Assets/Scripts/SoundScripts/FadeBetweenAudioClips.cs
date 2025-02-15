using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class FadeBetweenAudioClips : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip firstClip, secondClip;
    private float originalVolume;
    float timer;

    bool isFirstClip = false;
    bool isSecondClip = false;
    bool isSecondClipContinue = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = firstClip;
        audioSource.Play();
        originalVolume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // --- Temporary for Testing ---
        if(Input.GetKey(KeyCode.K))
        {
            StartCoroutine(FirstFadeToSecondClip());
            //isFirstClip = false;

            //isSecondClip = true;
        }
        if(Input.GetKey(KeyCode.L)) 
        {
            StartCoroutine(SecondFadeToFirstClip());
            //isFirstClip = true;

            //isSecondClip = false;         
        }

        //if(isSecondClip)
        //{
        //    timer += Time.deltaTime;
        //    if(timer > 2)
        //    {
        //        timer = 0;

        //        //audioSource.clip = secondClip;
        //        //audioSource.PlayOneShot(secondClip);
        //        SecondClipPlay();
        //        isSecondClip = false;
        //        isSecondClipContinue = true;
        //    }
        //    if(timer <= 2)
        //    {
        //        audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);              
        //    }
        //}
        //if (isSecondClipContinue)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > 2)
        //    {               
        //        audioSource.volume = 1;
                
        //        isSecondClipContinue = false;             
        //    }
        //    if (timer <= 2)
        //    {
        //        audioSource.volume = Mathf.Lerp(0, originalVolume, timer);
        //        Debug.Log("volume is: " + audioSource.volume);               
        //    }
        //}

    }

    void SecondClipPlay()
    {
        audioSource.clip = secondClip;
        audioSource.Play();
    }


    IEnumerator FirstFadeToSecondClip()
    {
        if(timer < 2)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
        }
        audioSource.clip = secondClip;
        audioSource.Play();
        yield return null;        
    }

    IEnumerator SecondFadeToFirstClip()
    {
        audioSource.clip = firstClip;       
        audioSource.Play();
        yield return null;
    }
}
