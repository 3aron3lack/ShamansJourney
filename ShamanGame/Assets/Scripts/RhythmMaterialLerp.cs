using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class RhythmMaterialLerp : MonoBehaviour
{
    public Material material;

    public Color emissionColor;
    public Color originalColor;



    public float speed = 1f;
    public float emissiveIntensity = 5f;
    public float waitTime = .5f;
    public float endTime = 1f;

    float startTime;

    float timer = 0f;
    Renderer renderer;
    Color matColor;

    bool isEmission;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();

        isEmission = false;

        matColor = renderer.material.color;

        renderer.sharedMaterial.SetColor("_EmissionColor", originalColor);
        renderer.sharedMaterial.EnableKeyword("_EMISSION");

        startTime = Time.time;



    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(LerpToEmissionEnd());
        //    StopCoroutine(LerpToEmissionEnd());
        //}


    }

    public void BlinkOnBeat()
    {
        StartCoroutine(LerpToEmissionCol());
        StopCoroutine(LerpToEmissionCol());
    }

    public void BlinkOnEnd()
    {
        StartCoroutine(LerpToEmissionEnd());
        StopCoroutine(LerpToEmissionEnd());
    }


    public IEnumerator LerpToEmissionEnd()
    {
        float elapsedTime = 0f;
        float thirdWaitTime = endTime / 4;

        while (elapsedTime <= endTime) 
        {
            if(elapsedTime < thirdWaitTime)
            {
                renderer.sharedMaterial.SetColor("_EmissionColor", Color.Lerp(originalColor, emissionColor * emissiveIntensity, (elapsedTime / endTime)));
                elapsedTime += Time.deltaTime;
            }
            else if(elapsedTime >= thirdWaitTime)
            {
                renderer.sharedMaterial.SetColor("_EmissionColor", Color.Lerp(emissionColor * emissiveIntensity, originalColor, (elapsedTime / endTime)));
                elapsedTime += Time.deltaTime;
            }

            yield return null;
        }
    }

    public IEnumerator LerpToEmissionCol()
    {
        float elapsedTime = 0f;
        float halfWaitTime = waitTime / 2;

        isEmission = true;

        while (elapsedTime <= waitTime) 
        {

            if (elapsedTime < halfWaitTime)
            {
                renderer.sharedMaterial.SetColor("_EmissionColor", Color.Lerp(originalColor, emissionColor * emissiveIntensity, (elapsedTime / waitTime)));
                elapsedTime += Time.deltaTime;
            }
            else if (elapsedTime >= halfWaitTime)
            {
                renderer.sharedMaterial.SetColor("_EmissionColor", Color.Lerp(emissionColor * emissiveIntensity, originalColor, (elapsedTime / waitTime)));
                elapsedTime += Time.deltaTime;
            }

            yield return null;
        }
        
    }
   
}
