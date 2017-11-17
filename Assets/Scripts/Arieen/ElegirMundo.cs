using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirMundo : MonoBehaviour {

	private bool esFantasia = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isFantasia() {
		return esFantasia;
	}

	public void isFantasia(bool fantasia) {
		esFantasia = fantasia;
	}
}
