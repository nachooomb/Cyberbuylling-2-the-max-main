using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamRegister : MonoBehaviour
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
