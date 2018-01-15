using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLoboP : MonoBehaviour {
    public PersonajeCOntrol pj;
    public CambiarSprite formas;
    

    public int repeatSalto;
    public bool frente = true;

    public Animator anim;
    // Use this for initialization
    void Awake()
    {
        pj = GameObject.Find("Arieen").GetComponent<PersonajeCOntrol>();
        formas = GameObject.Find("Arieen").GetComponent<CambiarSprite>();
        anim = this.GetComponent<Animator>();
        anim.enabled = false;
        repeatSalto = 0;
    }

    // Update is called once per frame
    void Update()
    {


        anim.enabled = true;

        if (formas.mundo=="Normal" && formas.sprite=="tierra")
        {
            this.transform.position = pj.transform.position;
            this.transform.Translate(Vector3.up * 3/7);
            
        }

        if (formas.mundo=="Rillion" || formas.sprite!="tierra")
        {
            this.transform.Translate(Vector3.right * 8000000);
        }



		if ((Input.GetKey(KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && frente)
        {
            frente = false;
            this.transform.Rotate(Vector3.up, 180, Space.Self);
        }

		if ((Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && frente == false)
        {
            frente = true;
            this.transform.Rotate(Vector3.up, 180, Space.Self);
        }

        if (pj.grounded)
        {

            anim.SetBool("idle", true);
            anim.SetBool("correr", false);
            anim.SetBool("salto", false);
            repeatSalto = 0;
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
            {
                anim.SetBool("idle", false);
                anim.SetBool("correr", true);
            }
        }

        else if (repeatSalto == 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("correr", false);
            anim.SetBool("salto", true);
            repeatSalto++;
        }

    }
 


}
