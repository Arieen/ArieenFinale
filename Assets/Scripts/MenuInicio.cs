using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour {

	public void CambiarANivel(string nuevoNivel) {
		SceneManager.LoadScene(nuevoNivel);
	}

	public void SalirDelJuego() {
		if (Application.isEditor) {
			UnityEditor.EditorApplication.isPlaying = false;
		}
		Application.Quit ();
	}
}
