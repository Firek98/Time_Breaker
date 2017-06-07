using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour {

	public int Activo = 1;
	public int random;
	public int spawnTime;
	public Vector2 spawnRange;
	public GameObject asteroide1;
	public GameObject asteroide2;
	public GameObject Jugador;

	void Start()
	{
		spawnRange.x = 9.87f;
		Jugador = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		if (Activo == 1) 
		{
			if (Jugador.GetComponentInChildren<Disparo> ().timeStopped == false) {
				StartCoroutine (GenerateAsteroid ());
			}
		}
	}

	IEnumerator GenerateAsteroid()
	{
		Activo = 0;
		yield return new WaitForSeconds (spawnTime);
		CrearAsteroide ();
		Activo = 1;

	}

	void CrearAsteroide()
	{
		random = Random.Range (0, 2);
		if (random == 0) {
			Vector2 spawnPosition = new Vector2 (spawnRange.x, Random.Range (-4.5f, 4.5f));
			Instantiate (
				asteroide1,
				spawnPosition,
				Quaternion.identity);
		}
	}
}
