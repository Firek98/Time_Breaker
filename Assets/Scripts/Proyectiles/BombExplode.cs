using UnityEngine;
using System.Collections;

public class BombExplode : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnTriggerEnter2D(Collider2D objeto)
    {
		if(objeto.GetComponent<Collider2D>().tag == "enemigo" || objeto.GetComponent<Collider2D>().tag == "enemigoIon")
        {
            Debug.Log("Bomb hit!");
            Destroy(this.gameObject);
        }
		if(objeto.GetComponent<Collider2D>().tag == "enemigoSpeedy")
		{
			Debug.Log("Bomb hit!");
			Destroy(this.gameObject);
		}
        if (objeto.GetComponent<Collider2D>().tag == "limitebalas")
        {
            Destroy(this.gameObject);
        }
    }
}
