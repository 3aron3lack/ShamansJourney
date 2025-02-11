using UnityEngine;

public class PlayerDialogueEndCamera : MonoBehaviour
{
    public CameraDialogueFocus currentDialogue;
    public CameraDialogueFocus newDialogue;

    public bool inDialogue = false;

    void Start()
    {
        
    }

    public void PlayerInDialogue()
    {
        inDialogue = true;
        
    }
    public void PlayerNotInDialogue()
    {
        newDialogue = null;
        inDialogue = false;
        currentDialogue = null;    
    }

    // Somehow get CameraDialogueFocus from current Dialogue you are interacting with.
    public void CurrentCameraDialogue()
    {
        //newDialogue = gameObject.GetComponent<CameraDialogueFocus>();

        currentDialogue = newDialogue;
        //currentDialogue.SwitchToPlayer();
        //newDialogue.SwitchToPlayer();
        currentDialogue.SwitchToPlayer();

    }


}
