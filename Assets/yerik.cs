using System.Collections;
using UnityEngine;

public class yerik : MonoBehaviour
{
    GameObject Arturo;
    Combate ArturoCombatStage;
    private Animator _animatorArturo;
    private Animator _animatorYerik;

    GameObject textofinal;

    public int VidaArturo = 104;

    bool CooldownATK;

    public float VidaYerik;
    [SerializeField] private Healthbar _healthbar;
    float vidaQuitar;
    int _contador = 0;
    float DMG = 0;
    void Start()
    {
        textofinal = GameObject.Find("TextoFinal");
        textofinal.SetActive(false);
        VidaArturo = 104;

        _contador = 0;
        DMG = 0;
        CooldownATK = true;

        StartCoroutine(Ataque());

        Arturo = GameObject.Find("Arturo");
        _animatorArturo = Arturo.GetComponent<Animator>();

        _animatorYerik = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VidaArturo > 0 && VidaYerik > 0)
        {
            StartCoroutine(Ataque());
        }
        //QuitarVida();

        //Debug.Log("Contador yerik" + _contador);
        if (_contador == InventoryManager.Instance.Items.Count)
        {
            _contador = 0;
        }

        if (_contador<=InventoryManager.Instance.Items.Count-1)
        { 
            //Debug.Log("DMG " + DMG);
            DMG = InventoryManager.Instance.Items[_contador].valueDMG;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            if (_contador == InventoryManager.Instance.Items.Count)
            {
                _contador = 0;
            } 
                
                //DMG = InventoryManager.Instance.Items[_contador].valueDMG;

                // Debug.Log("contadopr yerik " + _contador);

            if(_contador<=InventoryManager.Instance.Items.Count-1) 
            {
                 //Debug.Log("contador" + contador);
                //Debug.Log("lista" + InventoryManager.Instance.Items.Count);
                 _contador++; 
            }
        }
    }

    IEnumerator Ataque()
    {
        
        if (CooldownATK)
        {
            VidaArturo = VidaArturo- 5;
            _animatorArturo.SetTrigger("hit");
            _animatorArturo.SetTrigger("fight");
            CooldownATK =! CooldownATK;
            yield return new WaitForSeconds(6.0f);
            CooldownATK =! CooldownATK;
        }
        
    }


    void OnCollisionEnter()
    {
        QuitarVida();
        _healthbar.UpdateHealthBar(100, VidaYerik);
        _animatorYerik.SetTrigger("hit");
        if (VidaYerik <= 0)
        {
            //Debug.Log("Vida = 0 elegir final");
            _animatorYerik.SetBool("fight 0", true);
            if (_animatorYerik.GetBool("die 0") == false)
            {
                _animatorYerik.SetTrigger("die");
                _animatorYerik.SetBool("die 0", true);
            }

            _animatorArturo.SetTrigger("idle");


            //apagar controles

            textofinal.SetActive(true);
        }
        if (_animatorYerik.GetBool("fight 0") == false)
        {
            _animatorYerik.SetTrigger("fight");
        }
        
    }

    void QuitarVida()
    {
        vidaQuitar = DMG;
        
        VidaYerik = VidaYerik-vidaQuitar;

        Debug.Log("vida Yerik " + VidaYerik);
    }
}
