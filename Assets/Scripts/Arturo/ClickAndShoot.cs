using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClickAndShoot : MonoBehaviour
{
    GameObject Arturo;
    private control_arturo _control_arturo;
    private ClickAndMove clickAndMove;
    private Transform shooting_point; 
    private DialogueTrigger dialogueTrigger;

    //bool HePinchao = false;


    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        _control_arturo = Arturo.GetComponent<control_arturo>(); 
        clickAndMove = Arturo.GetComponent<ClickAndMove>();

        shooting_point = GameObject.Find ("shooting_point").GetComponent<Transform>();
        dialogueTrigger = GetComponent<DialogueTrigger>();

    }

    // Update is called once per frame
    void Update()
    {
        clickAndMove.GoDestination(shooting_point.position);
        if(clickAndMove.distanciaObjeto <= 0.1f){
            dialogueTrigger.TriggerDialogue();
        }

    }


}
