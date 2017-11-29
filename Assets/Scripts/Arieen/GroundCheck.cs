﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PersonajeCOntrol player;

    void Start()
    {
        player = gameObject.GetComponentInParent<PersonajeCOntrol>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Suelo") {
			player.grounded = true;
		}
    }

    void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Suelo") {
			player.grounded = true;
		}
    }

    void OnTriggerExit2D(Collider2D col)
    {

		if (col.tag == "Suelo") {
			player.grounded = false;
		}
    }
}
