using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour 
{
	public Rigidbody2D rd;
	public BoxCollider2D bc;
	public Rigidbody2D laser;

	private int timer = 0;
	// Use this for initialization
	void Start ()
	{
		rd = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		bc = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
		Globals.main = false;
	}

	void Update()
	{
		if (Globals.dead)
			Destroy (this.gameObject);
	}
	void FixedUpdate()
	{
		if (transform.position.x < -3.3f)
			rd.AddForce (Vector2.right, ForceMode2D.Impulse);
		if (transform.position.x > 3.3f)
			rd.AddForce (Vector2.left, ForceMode2D.Impulse);
		
		if (timer > 0)
			timer--;
		
		if (Input.GetKey ("right")&& (transform.position.x < 3.3f))
			rd.AddForce (Vector2.right, ForceMode2D.Impulse);
		if (Input.GetKey ("left") && (transform.position.x > -3.3f))
			rd.AddForce (Vector2.left, ForceMode2D.Impulse);
		
		if (Input.GetKey ("f") && timer <= 0) 
		{
			Instantiate(laser, rd.transform);
			timer = 10;
		}

	}


		
};
