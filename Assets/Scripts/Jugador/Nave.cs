using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Nave : MonoBehaviour {

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
    public KeyCode pausa;
    public float MandoY;
    public float MandoX;
	public float speed;
	public float finalspeed;
	public float limitex;
	public float limitey;
    public bool menu;
    public Canvas canvasmenu;
    bool Controller;
	public AudioSource healthDown;
	public AudioSource timeSlow;
	public AudioSource powerUp;

	public bool Tochas;
	public bool Doble;
	public bool Triple;
/*
	public GameObject balaSpawn1;
	public GameObject balaSpawn2;
	public GameObject balaSpawn3;*/

	public int vida;

	public Image Vida1;
	public Image Vida2;
	public Image Vida3;
	public Image Vida4;
	public Image Vida5;

	public bool balaDesactivada;
	public bool bombaDesactivada;
	public bool laserDesactivado;

	public Image FadeIn;

	public int puntos;
	public int nivel;
	public int nextLevel;

	public Text Scoretext;
	public Text Leveltext;
	public int puntosNecesarios;

	public AudioSource levelUp;

	public bool firstime;

	// Use this for initialization
	void Start () 
	{
		speed = 7f;
        menu = false;
        canvasmenu.enabled = false;
		nivel = 1;
		puntosNecesarios = 5000;
		firstime = true;
		/*balaSpawn1.SetActive (true);
		balaSpawn2.SetActive (false);
		balaSpawn3.SetActive (false);*/
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (menu == true)
        {
            canvasmenu.enabled = true;
            if (Input.GetKeyDown(pausa))
            {
				menu = false;
            }
        }
        if (menu == false)
        {
            canvasmenu.enabled = false;
            if (Input.GetKeyDown(pausa))
            {
                menu = true;
            }

            
           
            
                if (Input.GetKey(up))
                {

                    if (transform.localPosition.y > limitey)
                    {
                        finalspeed = 0;
                    }
                    else
                    {
                        finalspeed = speed;
                    }
                    transform.Translate(0, finalspeed * Time.deltaTime, 0);
                }
                if (Input.GetKey(down))
                {

                    if (transform.localPosition.y < -limitey)
                    {
                        finalspeed = 0;
                    }
                    else
                    {
                        finalspeed = speed;
                    }
                    transform.Translate(0, -finalspeed * Time.deltaTime, 0);
                }

                if (Input.GetKey(right))
                {

                    if (transform.localPosition.x > limitex)
                    {
                        finalspeed = 0;
                    }
                    else
                    {
                        finalspeed = speed;
                    }
                    transform.Translate(finalspeed * Time.deltaTime, 0, 0);
                }

                if (Input.GetKey(left))
                {

                    if (transform.localPosition.x < -limitex)
                    {
                        finalspeed = 0;
                    }
                    else
                    {
                        finalspeed = speed;
                    }
                    transform.Translate(-finalspeed * Time.deltaTime, 0, 0);
                }
            }
        
		HealthManager ();
		Scoretext.text = "Puntos: " + puntos.ToString();
		Leveltext.text = "Nivel: " + nivel.ToString();
		nextLevel = 1000*(nivel);
		if(puntos > nextLevel)
		{
			nivel++;
			levelUp.Play ();
		}
		if(puntos > puntosNecesarios)
		{
			puntosNecesarios += 5000;
			if(vida < 5)
			{
				vida++;
				powerUp.Play ();
			}
		}
    }

	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.GetComponent<Collider2D>().tag == "BalasTochas")
		{
			Tochas = true;
			puntos += 100;
			powerUp.Play();
		}
		if(objeto.GetComponent<Collider2D>().tag == "DisparoDoble")
		{
			Doble = true;
			puntos += 100;
			firstime = false;
			powerUp.Play();
		}
		if(objeto.GetComponent<Collider2D>().tag == "DisparoTriple")
		{
			Triple = true;
			puntos += 100;
			powerUp.Play();
		}
		if(objeto.GetComponent<Collider2D>().tag == "Energia")
		{
			GetComponentInChildren<Disparo> ().barDisplay = 0;
			GetComponentInChildren<Disparo> ().EnergyTime = GetComponentInChildren<Disparo> ().barDisplay;
			Debug.Log ("Energia pa tu body");
			powerUp.Play();
		}
		if(objeto.GetComponent<BoxCollider2D>().tag == "balaEnemiga")
		{
			vida--;
			healthDown.Play ();
		}
		if(objeto.GetComponent<BoxCollider2D>().tag == "balaTochaEnemiga")
		{
			vida-=2;
			healthDown.Play ();
		}
		if(objeto.GetComponent<BoxCollider2D>().tag == "enemigo")
		{
			vida--;
			healthDown.Play ();
		}
		if(objeto.GetComponent<Collider2D>().tag == "asteroide")
		{
			Debug.Log ("Asteroido");
			vida--;
			healthDown.Play ();
		}
		if(objeto.GetComponent<BoxCollider2D>().tag == "enemigoSpeedy")
		{
			vida-=2;
			healthDown.Play ();
		}
		if(objeto.GetComponent<BoxCollider2D>().tag == "enemigoIon")
		{
			vida--;
			healthDown.Play ();
			if(GetComponentInChildren<Disparo>().tipodisparo == 1)
			{
				GetComponentInChildren<Disparo>().disparodisable1 = true;
			}

			else if(GetComponentInChildren<Disparo>().tipodisparo == 2)
			{
				GetComponentInChildren<Disparo>().disparodisable2 = true;
			}

			else if(GetComponentInChildren<Disparo>().tipodisparo == 3)
			{
				GetComponentInChildren<Disparo>().disparodisable3 = true;
			}
		}
	}

	void HealthManager()
	{
		if (vida == 5) {
			Vida1.enabled = true;
			Vida2.enabled = true;
			Vida3.enabled = true;
			Vida4.enabled = true;
			Vida5.enabled = true;
		} else if (vida == 4) {
			Vida1.enabled = true;
			Vida2.enabled = true;
			Vida3.enabled = true;
			Vida4.enabled = true;
			Vida5.enabled = false;
		} else if (vida == 3) {
			Vida1.enabled = true;
			Vida2.enabled = true;
			Vida3.enabled = true;
			Vida4.enabled = false;
			Vida5.enabled = false;
		} else if (vida == 2) {
			Vida1.enabled = true;
			Vida2.enabled = true;
			Vida3.enabled = false;
			Vida4.enabled = false;
			Vida5.enabled = false;
		} else if (vida == 1) {
			Vida1.enabled = true;
			Vida2.enabled = false;
			Vida3.enabled = false;
			Vida4.enabled = false;
			Vida5.enabled = false;
		} else if (vida <= 0) {
			Vida1.enabled = false;
			Vida2.enabled = false;
			Vida3.enabled = false;
			Vida4.enabled = false;
			Vida5.enabled = false;
			Destroy (this.gameObject);
			FadeIn.GetComponent<Animator>().SetTrigger("Killed");
			Death ();
		}
	}

	void Death()
	{
		Application.LoadLevel("Muerte");
	}
		


}
