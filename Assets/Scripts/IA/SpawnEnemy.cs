using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{

	public GameObject enemigo1;
	public GameObject enemigo2;
	public GameObject enemigo3;
    public GameObject enemigo4;
	public float spawnTime;
	public Vector2 spawnRange;
	public float enemySpeed;
	public int Activo = 1;
	public int tipoenemigo;

	public int posibilidadNormal;
	public int posibilidadSpeedy;
	public int posibilidadTocho;
    public int posibilidadIonico;
	public GameObject Jugador;

	void Start()
	{
		Jugador = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate()
	{
		if (Activo == 1)
		{
			if(Jugador.GetComponentInChildren<Disparo> ().timeStopped == false)
			{
				StartCoroutine (GenerateEnemy ());
		
			}
		}
		spawnTime = 5 - Jugador.GetComponent<Nave> ().nivel;
		if(spawnTime < 1)
		{
			spawnTime = 0.75f;
		}
	}
		
	IEnumerator GenerateEnemy()
	{
		Activo = 0;
		yield return new WaitForSeconds (spawnTime);
		CrearEnemy ();
		Activo = 1;

	}

	void CrearEnemy()
	{
		tipoenemigo = Random.Range (0, 101);
        if (tipoenemigo > posibilidadNormal && tipoenemigo < posibilidadSpeedy)
        {
            Vector2 spawnPosition = new Vector2(spawnRange.x, Random.Range(-4.5f, 4.5f));
            Instantiate(
                enemigo1,
                spawnPosition,
                Quaternion.identity);
        }
        else if (tipoenemigo > posibilidadSpeedy && tipoenemigo < posibilidadTocho)
        {
            Vector2 spawnPosition = new Vector2(spawnRange.x, Random.Range(-4.5f, 4.5f));
            Instantiate(
                enemigo2,
                spawnPosition,
                Quaternion.identity);
        }
        else if (tipoenemigo > posibilidadTocho && tipoenemigo < posibilidadIonico)
        {
            Vector2 spawnPosition = new Vector2(spawnRange.x, Random.Range(-4.5f, 4.5f));
            Instantiate(
                enemigo3,
                spawnPosition,
                Quaternion.identity);
        }
        else if (tipoenemigo > posibilidadIonico)
        {
            Vector2 spawnPosition = new Vector2(spawnRange.x, Random.Range(-4.5f, 4.5f));
            Instantiate(
                enemigo4,
                spawnPosition,
                Quaternion.identity);
        }
    }

}
