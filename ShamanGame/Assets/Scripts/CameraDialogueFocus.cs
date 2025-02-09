using UnityEngine;
using Cinemachine;

public class CameraDialogueFocus : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [SerializeField] Transform playerTarget;
    [SerializeField] Transform newTarget;
    

    public void SwitchToTarget()
    {
        virtualCamera.LookAt = newTarget;
    }

    public void SwitchToPlayer()
    {
        virtualCamera.LookAt = playerTarget;
    }
    
}
