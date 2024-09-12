using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class ClickAndMove : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;

    public Animator ArturoAnim;

    private NavMeshAgent ArturoNavMesh;

    float lookRotationSpeed = 8f;

    public float distanciaObjeto;

    [SerializeField] ParticleSystem clickEffect;

    GameObject clickEffectClone;




    void Start()
    {
        ArturoNavMesh = GetComponent<NavMeshAgent>();
        ArturoAnim = GetComponent<Animator>();
        clickEffectClone = GameObject.Find("Click_Effect(Clone)");
    }

    void Update()
    {
        clickEffectClone = GameObject.Find("Click_Effect(Clone)");
        if (Input.GetMouseButtonDown(1))
        {
            Ray movementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;

            

            if (Physics.Raycast(movementRay, out rayHitInfo, 100, whatCanBeClickedOn))
            {
                ArturoNavMesh.SetDestination(rayHitInfo.point);
                if(clickEffect != null)
                {Instantiate(clickEffect, rayHitInfo.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
                //destroy click effect
            }

            FaceTarget();
            
            StartCoroutine(clickEffectCorrutina());
            
        }

        //Debug.Log(distanciaObjeto);
        distanciaObjeto = ArturoNavMesh.remainingDistance;

        if(ArturoNavMesh.remainingDistance>=0.1){
            ArturoAnim.SetBool("walkb", true);
        }else{
            ArturoAnim.SetBool("walkb", false);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (ArturoNavMesh.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    

    }

    public void GoDestination(Vector3 destinationPoint) 
    {
        ArturoNavMesh.SetDestination(destinationPoint);
        //FaceTarget();
        if(ArturoNavMesh.remainingDistance>=0.1){
            ArturoAnim.SetBool("walkb", true);
        }else{
            ArturoAnim.SetBool("walkb", false);
        }
    }

    IEnumerator clickEffectCorrutina()
    { 
        yield return new WaitForSeconds(2.0f);
        //Debug.Log("ClickEffectCorrutina");
        
        Destroy(clickEffectClone);
    }

}
