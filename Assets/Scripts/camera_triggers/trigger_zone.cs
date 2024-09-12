using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class trigger_zone : MonoBehaviour
{
    public bool oneShot = false;
    private bool alreadyEntered = false;
    private bool alreadyExited = false;

    public string collisionTag;

    public UnityEvent  onTriggerEnter;
    public UnityEvent  onTriggerExit;


    private void OnTriggerEnter( Collider col)
    {
        if (alreadyEntered)
        {
            return;
        } 
       
        if (!string.IsNullOrEmpty(collisionTag) && !col.CompareTag(collisionTag))
        {
            return;
        }

        onTriggerEnter?.Invoke();

        if (oneShot)
        {
            alreadyEntered = true;
        }

    }
    private void OnTriggerExit( Collider col)
    {
        if (alreadyExited)
        {
            return;
        }

        if (!string.IsNullOrEmpty(collisionTag) && !col.CompareTag(collisionTag))
        {
            return;
        }

        onTriggerExit?.Invoke();

        if (oneShot)
        {
            alreadyExited = true;
        }

        //Debug.Log(col.name);
    }
}
