using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuinicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    

    }

    public void StartGame(){

        Debug.Log("cambio");
        SceneManager.LoadScene("final");

    }


     public void ExitGame(){
        Application.Quit();
    }
}
