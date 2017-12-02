using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSprite : MonoBehaviour {

    public Sprite aire;
    public Sprite tierra;
    public Sprite mar;
	public string mundo = "ChangeCameraToNormal";


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
		/*thisRenderer = GetComponent<SpriteRenderer>();
		if (thisRenderer)
		{
			Shader _swapShader = Shader.Find("Custom/SwapTwo");
			if (!_swapShader)
			{
				Debug.LogError("You dont have shader... ");
			}
			else
			{
				Material _newMat = new Material(_swapShader);
				thisRenderer.material = _newMat;
				thisRenderer.material.SetTexture("_MainTex2", tierra1);
			}
		}
		else
		{
			Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);
		}*/
	}

    // Use this for initialization
    void Start () {
        pj = gameObject.GetComponent<PersonajeCOntrol>();
		//animator = GetComponent<Animator> ();
	}

	/*
	public void SwapTexture(Texture2D _toWhat)
	{
		//textura1 = _toWhat;
		if (thisRenderer)
		{
			Shader _swapShader = Shader.Find("Custom/SwapTwo");
			if (!_swapShader)
			{
				Debug.LogError("You dont have shader... ");
			}
			else
			{
				Material _newMat = new Material(_swapShader);
				thisRenderer.material = _newMat;
				thisRenderer.material.SetTexture("_MainTex2", _toWhat);
			}
		}
		else
		{
			Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);
		}
	}


	void estadoAnimador(string estado) {
		animator.SetBool("suelo_caminando1", false);
		animator.SetBool("suelo_caminando2", false);
		animator.SetBool("aire_volando1", false);
		animator.SetBool("aire_volando2", false);
		animator.SetBool (estado, true);
		GetComponent<BoxCollider2D> ().size = new Vector2 (thisRenderer.sprite.bounds.size.x, thisRenderer.sprite.bounds.size.y);
	}*/

	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<SpriteRenderer>().sprite != aire && Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aire;

            //this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire.rect.width/100, aire.rect.height/100);
            
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
               // this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra.rect.width / 100, tierra.rect.height / 100);
                sprite = "tierra";
               
                gameObject.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
                pj.FuerzaSalto = 400f;
                GameObject.Find("Arieen").gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            }
        }

		if (Input.GetKeyDown(KeyCode.C))
		{
			CambiarDeMundo ();
		}

		//pasamos a caminar normal
/*		if (Input.GetKeyDown(KeyCode.Alpha1) && pj.grounded) {		//pasamos a caminar
			if (!GetComponent<ElegirMundo> ().isFantasia ()) {		//normal
				if (animator.GetBool ("aire_volando1")) {
					SwapTexture (tierra1);
					estadoAnimador ("suelo_caminando1");
					//print (tierra1.width);
					//print (thisRenderer.sprite.bounds.size.y);
					//print (tierra.rect.width);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra1.width * thisRenderer.sprite.bounds.size.x /200, tierra1.width  * thisRenderer.sprite.bounds.size.x /200);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra1.width / 100, tierra1.height / 100);
				}
			} else {
				//if (Input.GetKeyDown(KeyCode.Alpha2) && pj.grounded) {
				if (animator.GetBool ("aire_volando2")) {
					SwapTexture (tierra2);
					estadoAnimador ("suelo_caminando2");
					//print (tierra2.width);
					//print (tierra.rect.width);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra2.height * thisRenderer.sprite.bounds.size.y /200, tierra2.height  * thisRenderer.sprite.bounds.size.y /200);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tierra2.width / 100, tierra2.height / 100);
				}
			}
		}

		//pasamos a volar normal
		if (Input.GetKeyDown(KeyCode.Alpha2)) {						//pasamos a volar
			if (!GetComponent<ElegirMundo> ().isFantasia ()) {		//normal
				if (animator.GetBool ("suelo_caminando1")) {
					SwapTexture (aire1);
					estadoAnimador ("aire_volando1");
					pj.FuerzaSalto = 150f;
					GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
					//print (aire1.width);
					//print (aire.rect.width);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire1.width * thisRenderer.sprite.bounds.size.x /200, aire1.width  * thisRenderer.sprite.bounds.size.x /200);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire1.width / 100, aire1.height / 100);
				}
			} else {
				if (animator.GetBool("suelo_caminando2")) {
					SwapTexture (aire2);
					estadoAnimador ("aire_volando2");
					pj.FuerzaSalto = 150f;
					GetComponent<Rigidbody2D>().gravityScale = 0.5f;
					//print (aire2.width);
					//print (aire.rect.width);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire2.height * thisRenderer.sprite.bounds.size.y /200, aire2.height  * thisRenderer.sprite.bounds.size.y /200);
					//gameObject.GetComponent<BoxCollider2D>().size = new Vector2(aire2.width / 100, aire2.height / 100);
				}
			}
		}


		//cambiamos de mundo
		if (Input.GetKeyDown(KeyCode.C)) {
			if (!GetComponent<ElegirMundo> ().isFantasia ()) {
				if (animator.GetBool ("suelo_caminando1")) {
					Debug.LogError ("error14");
					SwapTexture (tierra2);
					estadoAnimador ("suelo_caminando2");
					transform.localPosition = new Vector3 (-50, 50, 0);
				}
				if (animator.GetBool ("aire_volando2")) {
					SwapTexture (aire1);
					estadoAnimador ("aire_volando1");
					transform.localPosition = new Vector3 (-50, 50, 0);
				}
			} else {
				if (animator.GetBool ("suelo_caminando2")) {
					Debug.LogError ("error14");
					SwapTexture (tierra2);
					estadoAnimador ("suelo_caminando1");
					transform.localPosition = new Vector3 (-50, 0, 0);
				}
				if (animator.GetBool ("aire_volando1")) {
					SwapTexture (aire2);
					estadoAnimador ("aire_volando2");
					transform.localPosition = new Vector3 (-50, 0, 0);
				}
			}


			GetComponent<ElegirMundo> ().isFantasia (!GetComponent<ElegirMundo> ().isFantasia ());
		}

*/    }
	public void CambiarDeMundo() {
		if (mundo == "Normal") {
			pj.transform.position = new Vector3 (pj.transform.position.x, pj.transform.position.y + 50, pj.transform.position.z);
			mundo = "ChangeCameraToRillion";
		} else if (mundo == "Rillion") {
			pj.transform.position = new Vector3 (pj.transform.position.x, pj.transform.position.y - 50, pj.transform.position.z);
			mundo = "ChangeCameraToNormal";
		}
	}
}

