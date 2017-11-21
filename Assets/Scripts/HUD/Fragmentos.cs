using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fragmentos : MonoBehaviour {
    public int fragmentostotales = 10;
    public int fragmentosrecogidos = 0;
    public Text marcador;
	// Use this for initialization
	void Start () {
        actualizarmarcador();
    }

    void actualizarmarcador()
    {
        marcador.text = "" + fragmentosrecogidos + "/" + fragmentostotales;
    }
	
	// Update is called once per frame
	void Update () {
        actualizarmarcador();
	}
}
