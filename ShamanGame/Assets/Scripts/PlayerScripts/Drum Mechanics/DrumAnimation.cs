using UnityEngine;

public class DrumAnimation : MonoBehaviour
{
    private Animator animatorParams;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorParams = GameObject.FindWithTag("Kinsi").GetComponent<Animator>();
    }

    public void AnimationStart()
    {
        animatorParams.SetBool("isDrumming", true);
    }

    public void AnimationEnd()
    {
        animatorParams.SetBool("isDrumming", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
