using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelFade : MonoBehaviour
{
    public UnityEvent OnBlackScreen;

    public bool doFade = false;
    public float fadeRate;
    public float waitTime = 2;

    private Image panel;
    private Color c;
    private float timer = 0;
    private bool doFadeAgain = false;

    private void Start()
    {
        panel = GetComponent<Image>();
        panel.color = c;
    }

    public void FadeToBlackAndBack()
    {
        doFade = true;
    }

    // Update is called once per frame
    void Update()
    {
        // -- Temporary for Testing --
        //if(Input.GetKeyUp(KeyCode.O))
        //{
        //    Debug.Log(c.a);
        //   doFade = true;
        //}


        if(doFade)
        {
            panel.enabled = true;
            timer += Time.deltaTime;
            //Debug.Log(timer);
            c.a = Mathf.Lerp(0, 1, timer * fadeRate);
            panel.color = c;
            if (c.a >= 1f)
            {
                timer = 0;
                doFade = false;
                StartCoroutine(DramaticPause());
            }
        }

        if(doFadeAgain)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, timer * fadeRate);
            panel.color = c;
            if(c.a <= 0f)
            {
                timer = 0;
                panel.enabled = false;
                doFadeAgain = false;
            }
        }
    }

    IEnumerator DramaticPause()
    {     
        yield return new WaitForSeconds(waitTime);
        OnBlackScreen.Invoke();
        doFadeAgain = true;
    }
}
