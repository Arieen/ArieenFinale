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
    public BoxCollider2D BoundsRealWorld;
    public BoxCollider2D BoundsFantasyWorld;
    private float limite;

    //Marcos Estadísticas de vida
    public int currhealth;
    public int maxhealth = 3;

    // Use this for initialization

    void Start()
    {
        rd2b = gameObject.GetComponent<Rigidbody2D>();
        spriteActual = gameObject.GetComponent<CambiarSprite>();
        
        //Estadísticas Marcos
        currhealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        this.Movimiento();
        /* //if (spriteActual.sprite == "tierra"){

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
      //}

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
      }*/


    }

    void Movimiento()
    {
        if (!GameObject.Find("Main Camera").gameObject.GetComponent<MenuPausa>().paused)
        {
            if (spriteActual.mundo == "Rillion")
            {
                limite = (BoundsFantasyWorld.bounds.max.y - BoundsFantasyWorld.bounds.min.y)*0.7f + BoundsFantasyWorld.bounds.min.y;
            }
            if (spriteActual.mundo == "Normal")
                limite = (BoundsRealWorld.bounds.max.y - BoundsRealWorld.bounds.min.y)*0.7f + BoundsRealWorld.bounds.min.y;



            if (Input.GetKeyDown(KeyCode.Space) && ((grounded && spriteActual.sprite=="tierra") || (spriteActual.sprite=="aire" && personaje.position.y > limite)))
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
               /* if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.position = new Vector3(personaje.position.x + speed + 0.05f, personaje.position.y, personaje.position.z);
                }*/
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (isFacingRight)
                {
                    isFacingRight = !isFacingRight;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                transform.position = new Vector3(personaje.position.x - speed, personaje.position.y, personaje.position.z);
                /*if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.position = new Vector3(personaje.position.x - speed - 0.05f, personaje.position.y, personaje.position.z);
                }*/
            }
        }
    }
 
    void Life()
    {
        if (currhealth > maxhealth) { currhealth = maxhealth; }
        if (currhealth <= 0) { /*Die(); */}
    }
    //Marcos función de muerte
    void Die()
    {
        //Reiniciar el nivel
    }
}
