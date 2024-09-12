using UnityEngine;

public class Combate : MonoBehaviour
{
    public float VidaArturo;
    GameObject Yerik;
    yerik yerikScript;

    [SerializeField] private Healthbar _healthbar;

    void Start()
    {
        VidaArturo = 100;
        Yerik = GameObject.Find("Yerik_3D");
        yerikScript = Yerik.GetComponent<yerik>();
        _healthbar.UpdateHealthBar(100, VidaArturo);
        VidaArturo = yerikScript.VidaArturo;

    }

    // Update is called once per frame
    void Update()
    {
        VidaArturo = yerikScript.VidaArturo;

        _healthbar.UpdateHealthBar(100, VidaArturo);

        //Debug.Log("vida de artura " + VidaArturo);

        if (VidaArturo < 0 )
        {
            //Debug.Log("Arturo ha muerto");
        }
    }
}
