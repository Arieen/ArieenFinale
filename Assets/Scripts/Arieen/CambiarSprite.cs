using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSprite : MonoBehaviour {

    //Control animaciones
    

    //
    public Sprite aire;
    public Sprite tierra;
    public Sprite mar;
	public string mundo = "ChangeCameraToNormal";
    public bool atacando;
    public float timer;


	/*public Texture2D tierra1 = null;
	public Texture2D tierra2 = null;
	public Texture2D aire1 = null;
	public Texture2D aire2 = null;*/

    public string sprite = "tierra";


    PersonajeCOntrol pj;

	private SpriteRenderer thisRenderer;
	private Animator animator;

	private void Awake()
	{
		
	}

    // Use this for initialization
    void Start () {
        pj = gameObject.GetComponent<PersonajeCOntrol>();

        //Animaciones
        

    }


	// Update is called once per frame
	void Update () {
        this.cambiarforma();
        if (atacando == true)
        {
            timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds > 1)                            //TIEMPO QUE DURE LA ANIMACIÓN DE ATAQUE
            {
                atacando = false;
                timer = 0;
                seconds = 0;
            }
        }

        //Animaciones    

    }
	public void CambiarDeMundo() {
		if (sprite != "mar") {
			if (mundo == "Normal") {
				pj.transform.position = new Vector3 (pj.transform.position.x, pj.transform.position.y + 50, pj.transform.position.z);
				mundo = "ChangeCameraToRillion";

			} else if (mundo == "Rillion") {
				pj.transform.position = new Vector3 (pj.transform.position.x, pj.transform.position.y - 50, pj.transform.position.z);
				mundo = "ChangeCameraToNormal";
			}
		}
	}
    public void cambiarforma()
    {

		print (this.gameObject.GetComponent<SpriteRenderer> ().sprite);
		if (/*this.gameObject.GetComponent<SpriteRenderer>().sprite != aire && */Input.GetKeyDown(KeyCode.Alpha2) && pj.watered == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aire;

            //this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire.rect.width/100, aire.rect.height/100);

            sprite = "aire";
            pj.FuerzaSalto = 150f;
            pj.speed = 0.1f;
            GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }

        if (/*this.gameObject.GetComponent<SpriteRenderer>().sprite != mar && */Input.GetKeyDown(KeyCode.Alpha3) && mundo == "Normal")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = mar;
            //this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(mar.rect.width / 100, mar.rect.height / 100);
            sprite = "mar";
            pj.FuerzaSalto = 50f;
            
            pj.speed = 0.05f;
            GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        }

        if (/*this.gameObject.GetComponent<SpriteRenderer>().sprite != tierra && */Input.GetKeyDown(KeyCode.Alpha1) && pj.watered == false)
        {
			print("pulsado el 1");
            if (pj.grounded)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = tierra;
                // this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra.rect.width / 100, tierra.rect.height / 100);
                sprite = "tierra";

                //gameObject.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
                pj.FuerzaSalto = 400f;
                pj.speed = 0.1f;
                GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && pj.watered == false )
        {
            CambiarDeMundo();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && mundo == "Rillion")
        {
            atacando = true;
        }

        if ( pj.watered && (this.gameObject.GetComponent<SpriteRenderer>().sprite == tierra || this.gameObject.GetComponent<SpriteRenderer>().sprite != mar))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = mar;
            //this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(mar.rect.width / 100, mar.rect.height / 100);
            sprite = "mar";
            pj.FuerzaSalto = 250f;

            pj.speed = 0.05f;
            GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
        
       
    }
    public void cambioAgua()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = aire;

        //this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire.rect.width/100, aire.rect.height/100);

        sprite = "aire";
        pj.FuerzaSalto = 150f;
        pj.speed = 0.1f;
        GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }

    
}

