using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigos : MonoBehaviour {

	public GameObject bala;
	public float shootTime;
	public int Activo = 1;
	public Transform shootSpawn;
	public static float shootSpeed;
	public GameObject Jugador;

	void Start()
	{
		shootSpeed = 750;
		Jugador = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Jugador.GetComponentInChildren<Disparo> ().timeStopped == true)
		{
			Activo = 0;
		}
		if (Activo == 1) 
		{

			StartCoroutine(Disparar ());
		}
	}

	IEnumerator Disparar()
	{
		Activo = 0;
		yield return new WaitForSeconds (shootTime);
		Shoot ();
		Activo = 1;
	}

	void Shoot()
	{
		Instantiate (
			bala,
			shootSpawn.position,
			shootSpawn.rotation);
	}
}
