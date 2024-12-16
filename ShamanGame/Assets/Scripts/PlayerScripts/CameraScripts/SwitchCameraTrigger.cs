using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class SwitchCameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

    private CinemachineVirtualCamera camOnEnter;

    private bool hasEntered = false;
    void SwitchCamera()
    {

        if(camOnEnter == camera1)
        {
            CameraManager.SwitchCamera(camera2);
        }
        else if (camOnEnter == camera2)
        {
            CameraManager.SwitchCamera(camera1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !hasEntered)
        {
            if(camera1.Priority == 10)
            {
                camOnEnter = camera1;
            }
            if (camera2.Priority == 10)
            {
                camOnEnter = camera2;
            }
            hasEntered = true;
            SwitchCamera();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasEntered)
        {
            hasEntered = false;
        }
    }
}
