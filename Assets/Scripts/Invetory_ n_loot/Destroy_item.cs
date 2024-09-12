using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_item : MonoBehaviour
{
    //float timeDestroy = 2.0f;
    float time;
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //TimeDestroy();
        //OnCollisionEnter(Collision col);
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("choque " + col.gameObject.name);

        if (col.gameObject.name == "Yerik_3D" ){
            Destroy(gameObject);
        }

        if (col.gameObject.name == "paredes_rellano" || col.gameObject.name == "suelo_rellano")
        {
            StartCoroutine(timeCorrutina());
        }
    }

    // void TimeDestroy()
    // {
    //     if (Time.time >= time+timeDestroy)
    //     {
    //         Debug.Log("hola " + Time.time);
    //         Destroy(gameObject);
    //     }
    // }

    IEnumerator timeCorrutina()
    { 
        yield return new WaitForSeconds(2.0f);
        //Debug.Log("hola");
        Destroy(gameObject);
    }
}
