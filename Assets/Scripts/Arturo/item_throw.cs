using UnityEngine;


public class item_throw : MonoBehaviour
{

    public int contador = 0;
    
    private Animator _animatorArturo;

    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse0; 
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    void Start()
    {
        readyToThrow = true;    
        contador = 0;
        _animatorArturo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log("objeto " + InventoryManager.Instance.Items[contador].name);
        // Debug.Log("daño " + InventoryManager.Instance.Items[contador].valueDMG);
        // Debug.Log("tiros " + InventoryManager.Instance.Items[contador].numThrow);
        //Debug.Log("Contador Arturo" + contador);

        if (contador == InventoryManager.Instance.Items.Count)
        {
            contador = 0;
        }

        if (contador<=InventoryManager.Instance.Items.Count-1)
        { 
            //Debug.Log("objeto " + objectToThrow.name);
            objectToThrow = InventoryManager.Instance.Items[contador].Objeto;
        }

        if (Input.GetKeyDown(KeyCode.Space)){ 
            //Debug.Log("contador I" + contador);
            
            //objectToThrow = InventoryManager.Instance.Items[contador].Objeto;
            //totalThrows = InventoryManager.Instance.Items[contador].numThrow;


            // Debug.Log("objeto " + InventoryManager.Instance.Items[contador].name);
            // Debug.Log("daño " + InventoryManager.Instance.Items[contador].valueDMG);
            // Debug.Log("contador " + contador);

            //Debug.Log("tiros " + InventoryManager.Instance.Items[contador].numThrow);


            if(contador<=InventoryManager.Instance.Items.Count-1) 
            {
                //Debug.Log("contador" + contador);
                //Debug.Log("lista" + InventoryManager.Instance.Items.Count);
                contador++; 
            } 

            //Debug.Log("contador t" + contador);
        }


        // if (Input.GetKeyDown(KeyCode.G) && contador>= 0)
        // {
        //     contador --;
        // } else if  (contador<0)
        // {
        //     contador = InventoryManager.Instance.Items.Count-1;
        // }

        //Debug.Log("largo de la lista " + InventoryManager.Instance.Items.Count);


        
        //totalThrows = InventoryManager.Instance.Items[contador].numThrow;


        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0) 
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // instancia el objeto a lanazar
        GameObject proyectile = Instantiate(objectToThrow, attackPoint.position, attackPoint.rotation);

        //get rigid body component
        Rigidbody proyectileRB = proyectile.GetComponent<Rigidbody>();

        //calculate force direction
        Vector3 forceDirection = new Vector3(0, 0, 0);

        Ray aimingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //
        Vector3 rayDirection = Input.mousePosition - attackPoint.position;

        RaycastHit hit;

        if(Physics.Raycast(aimingRay, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
            Debug.DrawRay(attackPoint.position, hit.point, Color.green);
        } 
        //add force 
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        proyectileRB.isKinematic = false;
        proyectileRB.AddForce(forceToAdd, ForceMode.Impulse);

        //totalThrows = InventoryManager.Instance.Items[contador].numThrow;

        totalThrows --;

        //revisar animacion _animatorArturo.SetTrigger("throw");

        //Debug.Log(forceDirection);

        //Debug.DrawRay(attackPoint.position, hit.point, Color.green);


        //implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    } 

}
