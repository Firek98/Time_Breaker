using UnityEngine;
using System.Collections;

public class Animacion_Explosion : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GetComponentInParent<Enemigos>().muerte == true)
		{
			Explosion ();
		}
	}

    public void Explosion()
    {
        transform.position = transform.parent.position;
        transform.SetParent(null);
        Debug.Log("Animacion Explosion");
        GetComponent<Animator>().SetTrigger("Explosion_Trigger");
    }
}
