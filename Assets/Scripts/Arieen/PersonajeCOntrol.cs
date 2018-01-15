using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonajeCOntrol : MonoBehaviour
{

    public float FuerzaSalto;
	public float fuerzaAcuatica;
    public Transform personaje;
    public float speed;
	public float maxSpeedAgua;
	public float frenoEnAgua;
    public bool isFacingRight;
    public bool grounded;
    public bool watered;
    private Rigidbody2D rd2b;
    private CambiarSprite spriteActual;
    public BoxCollider2D BoundsRealWorld;
    public BoxCollider2D BoundsFantasyWorld;
    public BoxCollider2D BoundsWaterWorld;
    public BoxCollider2D col2;
	private float limite;
	private static int suavidezRotacionEnAgua = 60;
	private float[] ultimasVelocidades = new float[suavidezRotacionEnAgua];
	private int indiceVelocidades = 0;


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
        this.Life();

    }

    void Movimiento()
    {
        if (!GameObject.Find("Main Camera").gameObject.GetComponent<MenuPausa>().paused)
        {
            if (spriteActual.mundo == "Rillion")
            {
                limite = (BoundsFantasyWorld.bounds.max.y - BoundsFantasyWorld.bounds.min.y)*0.6f + BoundsFantasyWorld.bounds.min.y;
            }
            if (spriteActual.mundo == "Normal")
                limite = (BoundsRealWorld.bounds.max.y - BoundsRealWorld.bounds.min.y)*0.6f + BoundsRealWorld.bounds.min.y;


			if (spriteActual.transform.position.y <= BoundsWaterWorld.bounds.max.y) {
				watered = true;
				GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			} else if (spriteActual.transform.position.y > BoundsWaterWorld.bounds.max.y) {
                watered = false;
                GetComponent<Rigidbody2D>().rotation = 0;
                if (spriteActual.sprite == "mar")
				    GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                else if (spriteActual.sprite == "aire")
                    GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                else if (spriteActual.sprite == "tierra")
                    GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            }

			if (!watered) {
				if (Input.GetKeyDown (KeyCode.Space) && grounded && (spriteActual.sprite == "tierra" || (spriteActual.sprite == "aire" && (personaje.position.y > limite || grounded)) || spriteActual.sprite == "mar")) {
					rd2b.AddForce (Vector2.up * FuerzaSalto);
				}
				/*if (spriteActual.sprite == "agua")
					return;*/
				if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
					if (!isFacingRight) {
						isFacingRight = !isFacingRight; 
						GetComponent<SpriteRenderer> ().flipX = false;
					}
					transform.position = new Vector3 (personaje.position.x + speed, personaje.position.y, personaje.position.z);
					/* if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.position = new Vector3(personaje.position.x + speed + 0.05f, personaje.position.y, personaje.position.z);
                }*/
				}
				if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
					if (isFacingRight) {
						isFacingRight = !isFacingRight;
						GetComponent<SpriteRenderer> ().flipX = true;
					}
					transform.position = new Vector3 (personaje.position.x - speed, personaje.position.y, personaje.position.z);
					/*if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.position = new Vector3(personaje.position.x - speed - 0.05f, personaje.position.y, personaje.position.z);
                }*/
				}
			} else {
				//en el agua movimiento a base de fuerza para que sea más realista



				//rota para que la cabeza apunte en la dirección en que se mueve
				//se usa la media de las últimas velocidades para que no haga cambios bruscos en cada frame
				ultimasVelocidades[indiceVelocidades] = rd2b.velocity.y;
				indiceVelocidades++;
				if (indiceVelocidades >= ultimasVelocidades.Length)
					indiceVelocidades = 0;
				float media = 0.0f;
				foreach (float vel in ultimasVelocidades) {
					media += vel;
				}
				media = media / ultimasVelocidades.Length;
				if (!isFacingRight)
					media = -media;		//para que rote en la otra dirección si mira hacia el otro lado
				if (media > maxSpeedAgua)
					media = maxSpeedAgua;
				if (media < -maxSpeedAgua)
					media = -maxSpeedAgua;

				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
					//transform.position = new Vector3 (personaje.position.x, personaje.position.y + speed, personaje.position.z);
					if (rd2b.velocity.y < maxSpeedAgua) {
						rd2b.AddForce (Vector2.up * fuerzaAcuatica);
					}
				}
				if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
					if (rd2b.velocity.y > -maxSpeedAgua) {
						rd2b.AddForce (Vector2.down * fuerzaAcuatica);
					}
				}
				if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
					if (!isFacingRight)
						isFacingRight = true;
					if (rd2b.velocity.x < maxSpeedAgua) {
						rd2b.AddForce (Vector2.right * fuerzaAcuatica);
					}
				}
				if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
					if (isFacingRight)
						isFacingRight = false;
					if (rd2b.velocity.x > -maxSpeedAgua) {
						rd2b.AddForce (Vector2.left * fuerzaAcuatica);
					}
				}

				//aplica la rotacion
				GetComponent<Transform> ().eulerAngles = new Vector3 (0, 0, media * 10);
				//frena paulatinamente
				rd2b.AddForce (-rd2b.velocity * frenoEnAgua);


			}
        }
    }
 
    void Life()
    {
        
        if (currhealth == 0) { this.Die(); }
    }
    //Marcos función de muerte
    void Die()
    {
        currhealth = maxhealth;
        SceneManager.LoadScene("MainTestingGround");
        //Reiniciar el nivel
    }

    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "bordebot")
        {
            this.Die();
        }
    }
}
