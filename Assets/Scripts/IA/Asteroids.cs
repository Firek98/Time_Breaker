using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

	public static int asteroidSpeed;
	public GameObject Player;

	// Use this for initialization
	void Start () 
	{
		asteroidSpeed = 5;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate (-asteroidSpeed*Time.deltaTime,0,0);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<BoxCollider2D>().tag == "bala")
		{
			Player.GetComponent<Nave> ().puntos += 10;
			Destroy (this.gameObject, 0.01f);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "bala2")
		{
			Player.GetComponent<Nave> ().puntos += 10;
			Destroy (this.gameObject, 0.01f);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "bomba")
		{
			Player.GetComponent<Nave> ().puntos += 10;
			Destroy (this.gameObject, 0.01f);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "laser")
		{
			Player.GetComponent<Nave> ().puntos += 10;
			Destroy (this.gameObject, 0.01f);
		}
		if (collision.GetComponent<BoxCollider2D>().tag == "Player")
		{
			Player.GetComponent<Nave> ().puntos += 10;
			Destroy (this.gameObject, 0.01f);
		}

	}
}
