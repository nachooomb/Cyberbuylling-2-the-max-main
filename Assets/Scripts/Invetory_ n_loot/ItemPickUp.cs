using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemPickUp : MonoBehaviour
{
    public item Item;

    public GameObject Arturo;

    private NavMeshAgent ArturoNavMesh;

    public Animator ArturoAnim;

    private ClickAndMove clickAndMove;
    private control_arturo control_arturo;

    private DialogueTrigger dialogueTrigger;

    bool HePinchao = false;


    void Start ()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        ArturoNavMesh = Arturo.GetComponent<NavMeshAgent>();
        ArturoAnim = Arturo.GetComponent<Animator>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        control_arturo = Arturo.GetComponent<control_arturo>();
    }

    void Update (){
        //Debug.Log(clickAndMove.distanciaObjeto);
        if(HePinchao == false)  return;

        if(clickAndMove.distanciaObjeto == 0){ return;}


        if(clickAndMove.distanciaObjeto <= 0.1f)
            {
                PickUp();
                dialogueTrigger.TriggerDialogue();
                HePinchao=false;
            }
            //Debug.Log(clickAndMove.distanciaObjeto);
            
            

    }

    void PickUp()
    {
        InventoryManager.Instance.AddItem(Item);
        Destroy(gameObject); 
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
            //FaceTarget();

            if(ArturoNavMesh.remainingDistance>=0.1){
                //ArturoAnim.SetBool("walkb", true);
            }else{
                //ArturoAnim.SetBool("walkb", false);
                //PickUp();
            }
        }
    }

}
