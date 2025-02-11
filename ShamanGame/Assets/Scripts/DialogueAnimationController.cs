using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class DialogueAnimationController : MonoBehaviour
{

    [SerializeField] private UnityEvent OnAnimationStart;
    private float waitTimer = 2f;

    // This is really not clean coding, but I am too stupid or stuborn to make something else.
    [SerializeField] public LocalDialogueCheck localDialogue;

    

    public void StartAnimation()
    {
        if(OnAnimationStart == null)
        {
            Debug.Log("No Animation");
        }
        else
        {
            //OnAnimationStart.AddListener()
            if(localDialogue.inlocalDialogue)
            {
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


    IEnumerator TestCoroutine()
    {
        Debug.Log("WaitTimer Start");
        yield return new WaitForSeconds(waitTimer);
        Debug.Log("WaitTimer Finished");
    }
    
}
