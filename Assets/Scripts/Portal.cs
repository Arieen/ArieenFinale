using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	private GameObject jugador;
	//public GameObject tutoCorrespondiente;

	// Use this for initialization
	void Start () {
		jugador = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject == jugador) {
			//cambiar de mundo
			jugador.GetComponent<CambiarSprite>().CambiarDeMundo();

			//mostrar ayuda sobre el cambio de mundo
			//tutoCorrespondiente.SetActive(true);

			GameObject.Destroy (this.gameObject);
		}
	}

}
