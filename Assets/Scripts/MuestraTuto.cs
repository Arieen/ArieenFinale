using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraTuto : MonoBehaviour {

	public GameObject tutoCorrespondiente;
	public bool autoDestruible;
	public float segundosAutodestruccion;

	private GameObject jugador;
	public bool mostrado = false;



	// Use this for initialization
	void Start () {
		jugador = GameObject.FindGameObjectWithTag ("Player");
		foreach (GameObject imagenTuto in GameObject.FindGameObjectsWithTag("ImagenTutorial")) {
			imagenTuto.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D col) {
		//print ("entra en el collider");
		if (!mostrado) {		//como esto lo ignora lo destruiré cuando salga
			//print ("mostrado es " + mostrado);
			if (col.gameObject == jugador) {
				tutoCorrespondiente.SetActive (true);
				mostrado = true;
				//print ("mostrado es " + mostrado);

				if (autoDestruible) {
					//print ("es autodestruible");
					StopCoroutine (QuitarDespues ());
					StartCoroutine (QuitarDespues ());
				}
			}
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject == jugador) {
			tutoCorrespondiente.SetActive(true);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject == jugador) {
			tutoCorrespondiente.SetActive(false);
			GameObject.Destroy (this.gameObject);		//lo destruyo porque ignora si se ha mostrado alguna vez
		}
	}


	IEnumerator QuitarDespues() {
		print ("esperando para quitar");
		yield return new WaitForSeconds (segundosAutodestruccion);
		print ("ha pasado el tiempo");
		tutoCorrespondiente.SetActive (false);
		print ("quitado");
	}
}
