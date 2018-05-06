using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{

	public float speed = 3.0f;
	public Material gameover;
	public Material gamestart;
	public Material gamego;

	private Renderer r;
	private int timer = 100;

	void Start()
	{
		r = GetComponent<Renderer> ();
	}
	// Update is called once per frame
	void Update ()
	{
		if (!Globals.dead)
		{
			Vector2 offset = new Vector2 (0, Time.time * speed);
			r.material.mainTextureOffset = offset;
		}
		if (Globals.dead && timer > 0)
			timer--;
		if (Globals.dead && timer <= 0 && !Globals.main)
		{
			r.material.mainTextureOffset = Vector2.zero;
			r.material = gameover;

			if (Input.GetKey ("f") || Input.GetKey ("space")) 
			{
				Globals.main = true;
				r.material = gamestart;
			}
		}

		if (!Globals.dead && !Globals.main && r.material != gamego) 
		{
			r.material = gamego;
			timer = 100;
		}

		if (Globals.main)
			r.material = gamestart;

	}
}
