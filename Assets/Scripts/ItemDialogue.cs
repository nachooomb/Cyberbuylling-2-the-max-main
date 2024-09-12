using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemDialogue : MonoBehaviour
{

    GameObject Arturo;

    control_arturo control_arturo;

    private NavMeshAgent ArturoNavMesh;

    Animator ArturoAnim;

    private ClickAndMove clickAndMove;

    private DialogueTrigger dialogueTrigger;
    bool HePinchao = false;

    // Start is called before the first frame update
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        ArturoNavMesh = Arturo.GetComponent<NavMeshAgent>();
        ArturoAnim = Arturo.GetComponent<Animator>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        control_arturo = Arturo.GetComponent<control_arturo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HePinchao == false)  return;

        if(clickAndMove.distanciaObjeto == 0){ return;}


        if(clickAndMove.distanciaObjeto <= 0.1f){
            dialogueTrigger.TriggerDialogue();
            HePinchao = false;
        }
    }

    private void OnMouseDown()
    {
        GoDestinationPickUP(transform.position);

        HePinchao = true;
       
    }

   public void GoDestinationPickUP(Vector3 destinationPoint) 
    {
        if(control_arturo.itemInterac == true)
        {
            ArturoNavMesh.SetDestination(destinationPoint);
        }
       
    }
    
}
