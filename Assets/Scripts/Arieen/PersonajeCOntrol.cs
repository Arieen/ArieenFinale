using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeCOntrol : MonoBehaviour
{

    public float FuerzaSalto = 200f;
    public Transform personaje;
    public float speed = 0.01f;
    public bool isFacingRight = true;
    public bool grounded = true;
    private Rigidbody2D rd2b;
    private CambiarSprite spriteActual;

    // Use this for initialization

    void Start()
    {
        rd2b = gameObject.GetComponent<Rigidbody2D>();
        spriteActual = gameObject.GetComponent<CambiarSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteActual.sprite == "tierra"){

            if (!GameObject.Find("Main Camera").gameObject.GetComponent<MenuPausa>().paused)
            {
                if (Input.GetKeyDown(KeyCode.Space) && grounded)
                {
                    rd2b.AddForce(Vector2.up * FuerzaSalto);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    if (!isFacingRight)
                    {
                        isFacingRight = !isFacingRight;
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    transform.position = new Vector3(personaje.position.x + speed, personaje.position.y, personaje.position.z);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        transform.position = new Vector3(personaje.position.x + speed + 0.05f, personaje.position.y, personaje.position.z);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    if (isFacingRight)
                    {
                        isFacingRight = !isFacingRight;
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                    transform.position = new Vector3(personaje.position.x - speed, personaje.position.y, personaje.position.z);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        transform.position = new Vector3(personaje.position.x - speed - 0.05f, personaje.position.y, personaje.position.z);
                    }
                }
            }
        }

        if (spriteActual.sprite == "aire")
        {

            if (!GameObject.Find("Main Camera").gameObject.GetComponent<MenuPausa>().paused)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rd2b.AddForce(Vector2.up * FuerzaSalto);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    if (!isFacingRight)
                    {
                        isFacingRight = !isFacingRight;
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    transform.position = new Vector3(personaje.position.x + speed, personaje.position.y, personaje.position.z);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        transform.position = new Vector3(personaje.position.x + speed + 0.05f, personaje.position.y, personaje.position.z);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    if (isFacingRight)
                    {
                        isFacingRight = !isFacingRight;
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                    transform.position = new Vector3(personaje.position.x - speed, personaje.position.y, personaje.position.z);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        transform.position = new Vector3(personaje.position.x - speed - 0.05f, personaje.position.y, personaje.position.z);
                    }
                }
            }
        }


    }
}
