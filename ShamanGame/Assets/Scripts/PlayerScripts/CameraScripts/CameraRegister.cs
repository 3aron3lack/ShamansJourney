using UnityEngine;
using Cinemachine;

// -- Script by Raycastly --
// -- Link: https://www.youtube.com/watch?v=wmTCWMcjIzo --

public class CameraRegister : MonoBehaviour
{
    private void OnEnable()
    {
        CameraManager.Register(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {
        CameraManager.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}
