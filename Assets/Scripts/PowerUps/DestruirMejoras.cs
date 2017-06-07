using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMejoras : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.GetComponent<Collider2D>().tag == "Player")
		{
			Destroy (this.gameObject);
		}
	}

}
