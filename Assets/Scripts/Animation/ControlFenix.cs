using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFenix : MonoBehaviour {

    public PersonajeCOntrol pj;
    public CambiarSprite formas;

    public bool frente = true;


    // Use this for initialization
    void Start()
    {
        pj = GameObject.Find("Arieen").GetComponent<PersonajeCOntrol>();
        formas = GameObject.Find("Arieen").GetComponent<CambiarSprite>();
    }

    // Update is called once per frame
    void Update()
    {

        if (formas.mundo == "Rillion" && formas.sprite == "aire")
        {
            this.transform.position = pj.transform.position;
            this.transform.Translate(Vector3.up * 3 / 7);

        }

        if (formas.mundo == "Normal" || formas.sprite != "aire")
        {
            this.transform.Translate(Vector3.right * 8000000);
        }

        if (Input.GetKey(KeyCode.A) && frente)
        {
            frente = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.D) && frente == false)
        {
            frente = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }
}
