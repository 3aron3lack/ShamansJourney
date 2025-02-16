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
    bool isFirstClipContinue = false;
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
            //StartCoroutine(FirstFadeToSecondClip());
            //isFirstClip = false;

            isSecondClip = true;
        }
        if(Input.GetKey(KeyCode.L)) 
        {
            //StartCoroutine(SecondFadeToFirstClip());

            isFirstClip = true;

            //isSecondClip = false;         
        }

        FirstClipPlay();
        SecondClipPlay();

    }

    void SecondClipPlay()
    {
        
        if (isSecondClip && !isFirstClip)
        {
            if (audioSource.clip != secondClip)
            {
                audioSource.clip = secondClip;
                audioSource.Play();
            }

            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
            if (timer > 2)
            {
                audioSource.volume = 1;

                isSecondClip = false;
            }
        }

        //if (isSecondClip && !isFirstClip && !isSecondClipContinue)
        //{
        //    timer += Time.deltaTime;
        //    audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
        //    if (timer > 2)
        //    {
        //        timer = 0;

        //        audioSource.clip = secondClip;
        //        //audioSource.PlayOneShot(secondClip);
        //        audioSource.Play();

        //        isSecondClip = false;
        //        isSecondClipContinue = true;
        //    }
        //    //if (timer <= 2)
        //    //{
        //}
        //if (isSecondClipContinue)
        //{
        //    timer += Time.deltaTime;
        //    Debug.Log("Second Timer: " + timer);
        //    audioSource.volume = Mathf.Lerp(0, originalVolume, 0.1f * timer);
        //    if (timer > 2)
        //    {
        //        audioSource.volume = 1;

        //        isSecondClipContinue = false;
        //    }
        //}
    }

    void FirstClipPlay()
    {
        if(isFirstClip && !isSecondClip)
        {
            if (audioSource.clip != firstClip)
            {
                audioSource.clip = firstClip;
                audioSource.Play();
            }

            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
            if (timer > 2)
            {
                audioSource.volume = 1;

                isFirstClip = false;
            }
        }



        //if(isFirstClip && !isSecondClip && !isFirstClipContinue)
        //{
        //    timer += Time.deltaTime;
        //    audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
        //    if (timer > 2)
        //    {
        //        timer = 0;

        //        audioSource.clip = firstClip;
        //        //audioSource.PlayOneShot(firstClip);
        //        audioSource.Play();

        //        isFirstClip = false;
        //        isFirstClipContinue = true;
        //    }
        //}
        //if(isFirstClipContinue)
        //{
        //    timer += Time.deltaTime;
        //    Debug.Log("Second Timer: " + timer);
        //    audioSource.volume = Mathf.Lerp(0, originalVolume, 0.1f * timer);
        //    if (timer > 2)
        //    {
        //        audioSource.volume = 1;

        //        isFirstClipContinue = false;
        //    }
        //}

    }


    IEnumerator FirstFadeToSecondClip()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        audioSource.volume = Mathf.Lerp(originalVolume, 0, timer);
        if (timer > 2)
        {
            audioSource.volume = 0;
            yield return null;
        }
        //audioSource.clip = secondClip;
        //audioSource.Play();
               
    }

    IEnumerator SecondFadeToFirstClip()
    {
        audioSource.clip = firstClip;       
        audioSource.Play();
        yield return null;
    }
}
