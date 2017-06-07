using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour {

	public static int shootSpeed;
	public GameObject Jugador;


	// Use this for initialization
	void Start () 
	{
        shootSpeed = 700;
		Jugador = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-shootSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
	}

	void Update()
	{
		if(Jugador.GetComponentInChildren<Disparo>().timeStopped == true)
		{
			GetComponent<Rigidbody2D> ().Sleep ();
		}
		else
		{
			if(GetComponent<Rigidbody2D> ().IsAwake () == false)
			{
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-shootSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.GetComponent<BoxCollider2D>().tag == "Player")
		{
			Destroy (this.gameObject);
		}
		if (objeto.GetComponent<BoxCollider2D> ().tag == "limitenemigos") 
		{
			Destroy (this.gameObject);
		}
	}
}
