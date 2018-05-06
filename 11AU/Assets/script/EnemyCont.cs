using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour 
{
	public BoxCollider2D box;
	public Rigidbody2D	body;
	public Rigidbody2D laser;

	public bool right = true;
	private int timer = 100;

	// Use this for initialization
	void Start () 
	{
		transform.SetParent (null);
		body.AddForce (Vector2.down * 3.0f, ForceMode2D.Impulse);
		if (Random.Range (0f, 1.0f) > 0.5)
			right = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Globals.dead)
			Destroy (this.gameObject);

		if (!Globals.pause) 
		{
			if (right)
				body.AddForce (Vector2.right * 0.1f, ForceMode2D.Impulse);
			else
				body.AddForce (Vector2.left * 0.1f, ForceMode2D.Impulse);

			if (transform.position.x > 3.0f)
				right = false;
			if (transform.position.x < -3.0f)
				right = true;

			if (timer > 0)
				timer--;
			else 
			{
				Instantiate (laser, transform);

				timer = 100;
			}
		}
	}
}
