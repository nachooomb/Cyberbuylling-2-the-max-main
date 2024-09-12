using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class menu_script : MonoBehaviour
{

    private bool State = false;
    Animator _animatorMenu;
    // Start is called before the first frame update
    void Start()
    {
        _animatorMenu = GetComponent<Animator>();
        _animatorMenu.SetBool("Toggle_menu",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenu()
    {
        
        State = !State;
            
            _animatorMenu.SetBool("Toggle_menu",State);
    }
}
