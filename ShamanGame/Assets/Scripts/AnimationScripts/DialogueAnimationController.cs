using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class DialogueAnimationController : MonoBehaviour
{
    static DialogueAnimationController instance;

    //public DialogueAnimations [] dialogueAnimations;
    public DialogueAnimations dialogueAnimation;



    [SerializeField] private UnityEvent OnAnimationStart;

    private void Start()
    {
        //foreach (var anim in dialogueAnimations)
        //{
        //    Debug.Log("Name of dialogueAnimation is: " + anim.name);
        //}
        Debug.Log(dialogueAnimation.name);
    }

    public void StartAnimator()
    {
        //foreach(var anim in dialogueAnimations)
        //{
        //    if(anim.localDialogue)
        //    {
        //        OnAnimationStart.Invoke();
        //        Debug.Log("Invoking " + anim.name);
        //    }
        //}
        OnAnimationStart.Invoke();
        Debug.Log("Invoking " + dialogueAnimation.name);

    }

    public void StartAnimation(Animation anim)
    {

    }

}
