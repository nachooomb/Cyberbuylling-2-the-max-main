using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class control_arturo : MonoBehaviour
{
    public bool move = true;
    public bool combat = false;
    public bool shoot = false;
    public bool exploracionUI = true;
    public bool combateUI = false;
    public bool itemInterac = true;
    bool camaraInventarioInitialized = false;

    
    //private bool healthbarUI = false;

    GameObject Arturo;
    GameObject Yerik;

    public NavMeshAgent navMeshAgentArturo;
    public Rigidbody rigidbodyArturo;
    public yerik yerikScript;
    public ClickAndMove clickAndMove;
    public ClickAndShoot clickAndShoot;
    public item_throw item_Throw;
    public Combate combate;
    public Healthbar healthbarArturo;
    public Healthbar healthbarYerik;
    public GameObject[] ObjsCombate;
    public GameObject[] ObjsDialogo;
    public GameObject[] ObjsAbrir;

    public GameObject UIexploracion;
    public GameObject UIcombate;
    public GameObject UIhealthbarArturo;
    public GameObject UIhealthbarYerik;
    public GameObject DialogueManager;

    
    public CinemachineVirtualCamera camaraInventario;

    
    
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        clickAndShoot= Arturo.GetComponent<ClickAndShoot>();
        item_Throw= Arturo.GetComponent<item_throw>();
        combate = Arturo.GetComponent<Combate>();
        healthbarArturo = UIhealthbarArturo.GetComponent<Healthbar>();
        navMeshAgentArturo = Arturo.GetComponent<NavMeshAgent>();
        rigidbodyArturo = Arturo.GetComponent<Rigidbody>();
        //healthbarArturo = Arturo.GetComponentInChildren<Healthbar>();

        UIexploracion = GameObject.Find ("UI exploracion");
        UIcombate = GameObject.Find ("UI combate");
        //UIhealthbar = GameObject.Find ("Healthbar canvas");

        UIexploracion.SetActive (true);
        UIcombate.SetActive (false);

        DialogueManager = GameObject.Find ("DialogueManager");
        ObjsCombate = GameObject.FindGameObjectsWithTag ("ObjetosCombate");
        ObjsDialogo = GameObject.FindGameObjectsWithTag ("ObjetosDialogo");
        ObjsAbrir = GameObject.FindGameObjectsWithTag ("ObjetosAbrir");
        

        Yerik = GameObject.Find ("Yerik_3D");
        yerikScript = Yerik.GetComponent<yerik>();
        healthbarYerik = UIhealthbarYerik.GetComponent<Healthbar>();
    }

    // Update is called once per frame
    void Update()
    {
        //activar y desactivar el movimiento
        //SwitchModes();       
        ObjsCombate = GameObject.FindGameObjectsWithTag ("ObjetosCombate");
        ObjsCombate = GameObject.FindGameObjectsWithTag ("ObjetosDialogo");
        //ObjsCombate = GameObject.FindGameObjectsWithTag ("ObjetosAbrir");

    }

    public void ToggleMove()
    {
        move = !move;

        if (move == true) {
            clickAndMove.enabled = true;
        }
        if (move == false) {
            clickAndMove.enabled = false;
        }
    }

    public void ToggleUIexploracion()
    {
        exploracionUI = !exploracionUI;

        if (exploracionUI == true) {
            UIexploracion.SetActive(true);
        }
        if (exploracionUI == false) {
            UIexploracion.SetActive(false);
        }
    }

    public void ToggleCombat()
    {
        combat = !combat;

        if (combat == true) 
        {
            clickAndShoot.enabled = true;
        }
        if(combat == false) 
        {
            clickAndShoot.enabled = false;
        }
    }
    public void ToggleShoot()
    {
        shoot = !shoot;

        if (shoot == true) {
            item_Throw.enabled = true;
            yerikScript.enabled = true;
            combate.enabled = true;
            healthbarArturo.enabled = true;
            healthbarYerik.enabled = true;
        }
        if (shoot == false) {
            item_Throw.enabled = false;
            yerikScript.enabled = false;
            combate.enabled = false;
            healthbarArturo.enabled = false;
            healthbarYerik.enabled = false;
        }
    }

    public void ToggleUIcombate()
    {
        combateUI = !combateUI;

        if (combateUI == true) {
            UIcombate.SetActive(true);
            UIhealthbarArturo.SetActive(true);
            UIhealthbarYerik.SetActive(true);
        }
        if (combateUI == false) {
            UIcombate.SetActive(false);
            UIhealthbarArturo.SetActive(false);
            UIhealthbarYerik.SetActive(false);
        }
    }

    public void SwitchModes()
    {
       if (Input.GetKeyDown(KeyCode.M)){
            ToggleMove();
            ToggleCombat();
            ToggleUIexploracion();
            ToggleShoot();
            ToggleUIcombate();
        } 
        
    }

    public void ToggleEnterCombat()
    {

    }

    public void ToggleModeCombat()
    {
        
    }

    public void ToggleItemInterac()
    {
        //Debug.Log(itemInterac);
        itemInterac = !itemInterac;
        Debug.Log(itemInterac);
        foreach(GameObject objs in ObjsCombate)
        {
            if(objs.GetComponent<ItemPickUp>() != null)
            {
                objs.GetComponent<ItemPickUp>().enabled = itemInterac;
            }

            if(objs.GetComponent<Destroy_item>() != null)
            {
                objs.GetComponent<Destroy_item>().enabled = itemInterac;
            }

            if(objs.GetComponent<DialogueTrigger>() != null)
            {
                objs.GetComponent<DialogueTrigger>().enabled = itemInterac;            
            }
        }
        foreach(GameObject objs in ObjsDialogo)
        {
            if(objs.GetComponent<DialogueTrigger>() != null)
            {
                objs.GetComponent<DialogueTrigger>().enabled = itemInterac;            
            }

            if(objs.GetComponent<Abrir_Cerrar>() != null)
            {
                objs.GetComponent<Abrir_Cerrar>().enabled = itemInterac;            
            }            
        }
        foreach(GameObject objs in ObjsAbrir)
        {
            objs.GetComponent<Abrir_Cerrar>().enabled = itemInterac;
        }
        rigidbodyArturo.isKinematic = !itemInterac;
        navMeshAgentArturo.enabled = itemInterac;
    }

    public void ToggleCamaraInventariol()
    {
        Debug.Log(camaraInventarioInitialized);

        camaraInventarioInitialized = !camaraInventarioInitialized;
        Debug.Log(camaraInventarioInitialized);
        if (camaraInventarioInitialized == true) 
        {
            camaraInventario.Priority = 11;
        }
        if(camaraInventarioInitialized == false) 
        {
            Debug.Log("falso");
            camaraInventario.Priority = 0;
        }
    }
}
