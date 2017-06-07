using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemigos : MonoBehaviour {

	public int vida = 100;
	public int dañoBala = 20;
	public int dañoBala2 = 35;
	public int dañoBomba = 100;
	public int dañoLaser = 5;
	public static int enemyspeed;
	public int posibilidadDaño;
	public int posibilidadModificador;
	public int posibilidadEnergia;
	public int numeroRandom;

	public int numeroDrops;

	public GameObject Energia;
	public GameObject powerDaño;
	public GameObject powerDoble;
	public GameObject powerTriple;

	public GameObject jugador;

	public int TipoEnemigo;

	public Transform player;

	public Vector2 posicion;

	public GameObject disparoEnemigos;

	public bool muerte;
	public GameObject Particulas;
	public Animator Animacion_Particulas;

	// Use this for initialization
	void Start () 
	{
		muerte = false;
        if(TipoEnemigo==1)
        {
            enemyspeed = 5;
        }
		else if(TipoEnemigo == 3)
		{
			enemyspeed = 3;
		}
		else if(TipoEnemigo==2)
        {
            enemyspeed = 8;
        }
      
		numeroDrops = 1;
		jugador = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(vida <= 0)
		{
			numeroRandom = Random.Range (0,106);
			if(numeroRandom > posibilidadDaño && numeroRandom < posibilidadModificador)
			{
				DropDaño ();
			}
			if(numeroRandom > posibilidadModificador && numeroRandom < posibilidadEnergia)
			{
				if(jugador.GetComponent<Nave>().firstime == true)
				{
					DropModificadorDoble ();
					jugador.GetComponent<Nave> ().firstime = true;
				}
				else
				{
					DropModificadorTriple ();
				}
			}
			if(numeroRandom > posibilidadEnergia)
			{
				DropEnergia ();
			}
			if(TipoEnemigo == 1)
			{
				jugador.GetComponent<Nave> ().puntos += 100;
			}
			else if(TipoEnemigo == 2)
			{
				jugador.GetComponent<Nave> ().puntos += 80;
			}
			else if(TipoEnemigo == 3)
			{
				jugador.GetComponent<Nave> ().puntos += 150;
			}
			muerte = true;
			Destroy (this.gameObject, 0.01f);
		}
		/*else if (TipoEnemigo == 2) 
		{
			Vector3 posicion = new Vector3 (player.position.x, player.position.y, player.position.z);
			transform.LookAt(posicion);
			transform.eulerAngles = new Vector3 (0, 0, transform.rotation.z);
		}*/
		transform.Translate (-enemyspeed*Time.deltaTime,0,0);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<BoxCollider2D>().tag == "bala")
		{
			vida -= dañoBala;
			Particulas.SetActive (true);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "bala2")
		{
			vida -= dañoBala2;
			Particulas.SetActive (true);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "bomba")
		{
			vida -= dañoBomba;
			Particulas.SetActive (true);
		}
		if (collision.GetComponent<BoxCollider2D> ().tag == "Player") 
		{
			Destroy (this.gameObject);
		}
		if (collision.GetComponent<BoxCollider2D> ().tag == "limitenemigos") 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D objeto)
	{
		if(objeto.GetComponent<BoxCollider2D>().tag == "laser")
		{
			Debug.Log ("Laser");
			vida -= dañoLaser;
		}
	}

	void DropDaño()
	{
		var powerup = (GameObject)Instantiate (
			powerDaño,
			transform.position,
			Quaternion.identity);
	}

	void DropModificadorDoble()
	{
		var powerup = (GameObject)Instantiate (
			powerDoble,
			transform.position,
			Quaternion.identity);
	}

	void DropModificadorTriple()
	{
		var powerup = (GameObject)Instantiate (
			powerTriple,
			transform.position,
			Quaternion.identity);
	}

	void DropEnergia()
	{
		var powerup = (GameObject)Instantiate (
			Energia,
			transform.position,
			Quaternion.identity);
	}
}
