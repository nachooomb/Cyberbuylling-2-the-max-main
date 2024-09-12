using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrir_Cerrar : MonoBehaviour
{
    private Animator _animator;
    private int _contador; 
    void Start()
    {
        _animator = GetComponent<Animator>();
        _contador = 0; 
    }

    // Update is called once per frame
    void abrir_cerrar()
    {
        if (_animator != null)
        {
            if (_contador == 1)
            {
                Debug.Log("Abrir");
                _animator.SetTrigger("Abrir");
            }
            if (_contador == 2)
            {
                _animator.SetTrigger("Cerrar");
                Debug.Log("Cerrar");
            }
        }

        if (_contador == 2)
        {
            _contador=0;
        }

        Debug.Log(_contador);
    }

    void OnMouseDown()
    {
        _contador++;
        if (_contador >= 1)
        abrir_cerrar();
    }
}

