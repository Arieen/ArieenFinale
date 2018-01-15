using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemigoChoque : MonoBehaviour {

	public Sprite[] vidas;
	PersonajeCOntrol personajeControl;
	public Image imagenvidas;
	bool vulnerable;
	public float tiempoInvulnerable;
	public Color colorTransp;
	public Color colorNoTransp;
    CambiarSprite cambiarSprite;

	// Use this for initialization
	void Start () {
		personajeControl = GetComponent<PersonajeCOntrol> ();
        cambiarSprite = GetComponent<CambiarSprite>();
		vulnerable = true;
	}

	void Transparencia(bool transparente)
	{
		if (transparente)
			GetComponent<SpriteRenderer> ().color = colorTransp;
		else
			GetComponent<SpriteRenderer> ().color = colorNoTransp;
	}

	void OnTriggerEnter2D (Collider2D other)
	{

        if (other.tag == "Enemigo" && cambiarSprite.atacando) {
            other.GetComponent<movimientoEnemigo>().vivo = false;//Borrar enemigo
        }

        else if (other.tag == "Enemigo" && vulnerable)
        {
            personajeControl.currhealth--;
            Invulnerable();
        }
        
	}

	void Invulnerable()
	{
		StartCoroutine (InvulnerableIEnume ());
	}

	IEnumerator InvulnerableIEnume()
	{
		vulnerable = false;
		Transparencia (true);
		yield return new WaitForSeconds (tiempoInvulnerable);
		vulnerable = true;
		Transparencia (false);
	}
}
