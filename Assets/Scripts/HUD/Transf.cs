using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transf : MonoBehaviour {

    public Sprite[] Tsprites;

    public Image TransfUI;

    private CambiarSprite personaje;

    private void Start()
    {
        personaje = GameObject.Find("Arieen").GetComponent<CambiarSprite>();
    }

    private void Update()
    {
        if (personaje.sprite == "tierra"){
            TransfUI.sprite = Tsprites[1];
        }

        else if (personaje.sprite == "aire"){
            TransfUI.sprite = Tsprites[0];
        }

        else {
            TransfUI.sprite = Tsprites[2];
        }
        
    }
}
