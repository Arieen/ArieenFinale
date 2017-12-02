using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientofondo : MonoBehaviour {
    public float velocidad;

    private Vector3 moverpj, anteriorpj;

	// Use this for initialization
	void Start () {

        moverpj = GameObject.Find("Arieen").transform.position;
        anteriorpj = moverpj;

	}
	
	// Update is called once per frame
	void Update () {
        moverpj = GameObject.Find("Arieen").transform.position;
     
        
        if (moverpj!=anteriorpj)
        {
            
            if (Input.GetKey(KeyCode.D))
            {
                
                this.transform.Translate(Vector3.right * velocidad);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                
                this.transform.Translate(Vector3.left * velocidad);
            }

            anteriorpj = moverpj;
        }

        else 
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.left * velocidad);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(Vector3.right * velocidad);
            }
            
        }
        

    }
}
