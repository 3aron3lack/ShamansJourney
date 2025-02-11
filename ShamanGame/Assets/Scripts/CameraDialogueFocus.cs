using UnityEngine;
using Cinemachine;

public class CameraDialogueFocus : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    //[SerializeField] PlayerDialogueEndCamera dialogue;
    [SerializeField] Transform playerTarget;
    [SerializeField] Transform newTarget;

    private void Start()
    {
        //newTarget = gameObject.transform;
    }

    public void SwitchToTarget()
    {
        
        virtualCamera.LookAt = newTarget;
        Debug.Log("New Target is: " + newTarget.name);
        //newTarget = null;
    }

    public void SwitchToPlayer()
    {
        virtualCamera.LookAt = playerTarget;
    }
    public void NoTarget()
    {
        newTarget = null;
    }
    public void NewTarget()
    {
        newTarget = gameObject.transform;
    }
    
}
