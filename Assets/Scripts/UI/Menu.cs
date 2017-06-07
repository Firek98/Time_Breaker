using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
	public int estado = 1;
	public KeyCode Arriba;
	public KeyCode Abajo;

	public Button Jugar;
	public Button Tienda;
	public Button Salir;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(Arriba))
		{
			if(estado > 1)
			{
				estado--;
			}
		}
		if(Input.GetKeyDown(Abajo))
		{
			if (estado < 3) 
			{
				estado++;
			}
		}

		if(estado == 1)
		{
			
		}
	}
}
