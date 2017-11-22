using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour {

    public bool paused = false;

    public GameObject PauseUI;
	// Use this for initialization
	void Start () {

        PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause")){

            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        } 
	}

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainTestingGround");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Quit()
	{
		if (Application.isEditor) {
			UnityEditor.EditorApplication.isPlaying = false;
		}
        Application.Quit();
    }
}
