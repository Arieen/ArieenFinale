using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Sprite[] LifeSprites;

    public Image LifeUI;

    private PersonajeCOntrol personaje;

    private void Start()
    {
        personaje = GameObject.Find("Arieen").GetComponent<PersonajeCOntrol>();
    }

    private void Update()
    {
        
            LifeUI.sprite = LifeSprites[personaje.currhealth - 1];

        
    }
}
