using UnityEngine;
using System.Collections;

public class BalaExplode : MonoBehaviour
{
	public int shootspeed = 750;
	void Start()
	{
		GetComponent<Rigidbody2D> ().AddForce ((new Vector2(shootspeed * Time.deltaTime, 0)), ForceMode2D.Impulse);
	}

    void OnTriggerEnter2D(Collider2D objeto)
    {
		if (objeto.GetComponent<Collider2D>().tag == "enemigo" || objeto.GetComponent<Collider2D>().tag == "enemigoIon" || objeto.GetComponent<Collider2D>().tag == "enemigoSpeedy")
        {
            Destroy(this.gameObject);
        }

		if (objeto.GetComponent<Collider2D>().tag == "limitebalas" || objeto.GetComponent<Collider2D>().tag == "asteroide")
        {
            Destroy(this.gameObject);
        }
    }
}
