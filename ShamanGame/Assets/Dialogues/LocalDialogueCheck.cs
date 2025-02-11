using UnityEngine;

public class LocalDialogueCheck : MonoBehaviour
{

    [SerializeField]
    [HideInInspector] public bool inlocalDialogue = false;

    public void InLocalDialogue()
    {
        inlocalDialogue = true;
    }
    public void NotInLocalDialogue()
    {
        inlocalDialogue = false;
    }

    public void CheckLocalDialogueAtEnd()
    {
        if(inlocalDialogue)
        {
            NotInLocalDialogue();
        }
        else
        {
            Debug.Log(this.gameObject.name + " is not the current dialog");
        }
    }


}
