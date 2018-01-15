using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigo : MonoBehaviour {

	Animator animator;
	bool direccion;
	public float velocidad;
    public bool vivo = true;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (vivo)
        {
            if (direccion)
                this.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            else
                this.transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
        else
        {
            Destroy(this.animator);
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponentInChildren<SkinnedMeshRenderer>());
        }
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
