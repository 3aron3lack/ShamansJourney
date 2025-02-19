using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DialogueAnimations : MonoBehaviour
{
    [SerializeField] private UnityEvent OnAnimationStart;
    [SerializeField] private string TriggerName;
    private float waitTimer = 2f;


    // This is really not clean coding, but I am too stupid or stuborn to make something else.
    [SerializeField] public LocalDialogueCheck localDialogue;

    public bool isAnimation = true;

    [SerializeField] private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        //Debug.Log("ANIMATION IS START: " + name);
        if (OnAnimationStart == null)
        {
            Debug.Log("Local Dialogue is false");
        }
        else
        {
            //OnAnimationStart.AddListener()
            if (localDialogue.inlocalDialogue)
            {
                Debug.Log("Local Dialogue is true");
                OnAnimationStart.Invoke();
            }
            //foreach (var dialogue in localDialogue)
            //{
            //    if (dialogue.inlocalDialogue)
            //        OnAnimationStart.Invoke();
            //}

        }
    }
    public void TestResponse()
    {
        //float timer = 0f;

        //timer += Time.deltaTime;
        //if(timer > waitTimer)
        //{
        //    Debug.Log("TestDone");
        //}
        Debug.Log("First Response");
        //StartCoroutine(TestCoroutine());
    }
    public void TestResponse2()
    {
        Debug.Log("Second Response");
    }

    public void TestAnimation()
    {
        if (isAnimation)
            animator.SetTrigger(TriggerName);
        else
            Debug.Log("Nothing lol");
    }

    public void AnimationTrue()
    {
        animator.SetBool("DoShake", true);
    }
    public void AnimationFalse()
    {
        animator.SetBool("DoShake", false);
    }


    public void AnimtationBoolOff()
    {
        isAnimation = false;
    }
    public void AnimtationBoolOn()
    {
        isAnimation = true;
    }


    //IEnumerator TestCoroutine()
    //{
    //    Debug.Log("WaitTimer Start");
    //    yield return new WaitForSeconds(waitTimer);
    //    Debug.Log("WaitTimer Finished");
    //}
}
