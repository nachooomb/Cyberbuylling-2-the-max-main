using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using UnityEngine.InputSystem;



public class trigger_detector : MonoBehaviour
{
    public CinemachineVirtualCamera cam2salon;
    public CinemachineVirtualCamera cam2wc;
    private void OnTriggerEnter( Collider col)
    {
         Debug.Log(col.name);
         if ( col.name == "Trigger_camara_salon" && Input.GetKeyDown(KeyCode.C))
         {
            CameraManager.SwitchCamera(cam2salon);
         }

         if ( col.name == "Trigger_camara_WC" && Input.GetKeyDown(KeyCode.C))
         {
            CameraManager.SwitchCamera(cam2wc);
         }
    }
    
}
