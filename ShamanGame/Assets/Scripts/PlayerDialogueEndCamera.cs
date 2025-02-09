using UnityEngine;

public class PlayerDialogueEndCamera : MonoBehaviour
{
    CameraDialogueFocus currentDialogue;
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
        inDialogue = false;
    }

    // Somehow get CameraDialogueFocus from current Dialogue you are interacting with.
    public void CurrentCameraDialogue()
    {
        //newDialogue = gameObject.GetComponent<CameraDialogueFocus>();

        currentDialogue = newDialogue;

        currentDialogue.SwitchToPlayer();
    }


}
