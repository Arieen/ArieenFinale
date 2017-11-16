using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSprite : MonoBehaviour {

    public Sprite aire;
    public Sprite tierra;
    public Sprite mar;

    public string sprite = "tierra";

    PersonajeCOntrol pj;



    // Use this for initialization
    void Start () {
        pj = gameObject.GetComponent<PersonajeCOntrol>();
}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<SpriteRenderer>().sprite != aire && Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aire;
            this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire.rect.width/100, aire.rect.height/100);

            sprite = "aire";
            pj.FuerzaSalto = 150f;
            GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }

        if (this.gameObject.GetComponent<SpriteRenderer>().sprite != mar && Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = mar;
            this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(mar.rect.width / 100, mar.rect.height / 100);
            sprite = "mar";
        }

        if (this.gameObject.GetComponent<SpriteRenderer>().sprite != tierra && Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (pj.grounded)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = tierra;
                this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra.rect.width / 100, tierra.rect.height / 100);
                sprite = "tierra";
                gameObject.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
            }
            

        }
    }
}
