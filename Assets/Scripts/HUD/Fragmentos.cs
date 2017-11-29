using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Fragmentos : MonoBehaviour {
	public int fragmentostotales;
	public int fragmentosrecogidos;
    public Text marcador;
	// Use this for initialization

	void Awake()
	{
		marcador.text = "" + Convert.ToString (fragmentosrecogidos) + "/" + Convert.ToString (fragmentostotales);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Fragmentos") {
			fragmentosrecogidos++;
			marcador.text = "" + Convert.ToString (fragmentosrecogidos) + "/" + Convert.ToString (fragmentostotales);
			Destroy (other.gameObject);
			Debug.Log("tocado");
		}
	}
   
}
