using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigo : MonoBehaviour {

	Animator animator;
	bool direccion;
	public float velocidad;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (direccion)
			this.transform.Translate (Vector2.left * velocidad * Time.deltaTime);
		else 
			this.transform.Translate (Vector2.right * velocidad * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "TopeEnemigo") {
			direccion = !direccion;
			Vector3 vectorContrario = transform.localScale;
			vectorContrario.x *= -1;

			transform.localScale = vectorContrario;

			//Debug.Log ("tocado");
		}
	}
}
