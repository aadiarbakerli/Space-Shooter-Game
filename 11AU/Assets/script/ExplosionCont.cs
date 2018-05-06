using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCont : MonoBehaviour 
{

	private	int timer = 8;
	public AudioSource boom;
	// Use this for initialization
	void Start ()
	{
		transform.parent = null;
		boom.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (timer > 0)
			timer--;
		else 
		{
			DestroyImmediate (this.gameObject);
		}
	}
}
