using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosplataformaY : MonoBehaviour {
    //Animator animator;
    int direccion = 1;
    public float velocidad;
    private int contador = 0;
    // Use this for initialization
    void Start()
    {
        //animator = this.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 180)

        {
            contador *= -1;
            direccion = 2;

        }
        if (contador == 0)
        {
            direccion = 1;
        }

        if (direccion == 1)
        {
            contador++;
            this.transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        }

        else
        {
            this.transform.Translate(Vector2.up * -velocidad * Time.deltaTime);
            contador++;
        }

    }



    /* void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag == "TopePlat")
         {
             if (direccion == 1)
             {
                 direccion = 2;
             }
             else
                 direccion = 1;

             Debug.Log("tocado");
         }
     }*/
}
