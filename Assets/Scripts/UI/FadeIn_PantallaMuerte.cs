using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn_PantallaMuerte : MonoBehaviour {


	public Image Marco;
	public float timeLeft;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
		}
		if ( timeLeft <= 0 )
		{
			Marco.enabled = false;
		}
	}
}
