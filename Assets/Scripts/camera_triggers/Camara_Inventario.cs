using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camara_Inventario : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera camaraInventario;
    bool camaraInventarioInitialized = false;

    public void ToggleCamaraInventariol()
    {
        camaraInventarioInitialized = !camaraInventarioInitialized;
        if (camaraInventario == true) 
        {
            camaraInventario.Priority = 11;
        }
        if(camaraInventario == false) 
        {
            camaraInventario.Priority = 0;
        }
    }
}
