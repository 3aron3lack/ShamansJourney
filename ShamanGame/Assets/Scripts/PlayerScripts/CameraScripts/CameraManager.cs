using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using NUnit.Framework;
using UnityEditor;

// -- Script by Raycastly --
// -- Link: https://www.youtube.com/watch?v=wmTCWMcjIzo --

public class CameraManager : MonoBehaviour
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        newCamera.Priority = 10;
        newCamera.enabled = true;
        ActiveCamera = newCamera;
        
        foreach(CinemachineVirtualCamera cam in cameras)
        {
            if(cam != newCamera)
            {
                cam.Priority = 0;
                cam.enabled = false;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
