using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraTuto : MonoBehaviour {

	private GameObject jugador;
	public GameObject tutoCorrespondiente;
	public bool autoDestruible;
	public float segundosAutodestruccion;

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
		if (col.gameObject == jugador) {
			tutoCorrespondiente.SetActive(true);

			if (autoDestruible) {
				print ("es autodestruible");
				StopCoroutine (QuitarDespues ());
				StartCoroutine (QuitarDespues ());
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
