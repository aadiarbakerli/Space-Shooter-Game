using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstCont : MonoBehaviour 
{
	public int hp = 5;
	public bool big = true;
	public Rigidbody2D rd;
	public Rigidbody2D small;
	public Transform explosion;

	void Start()
	{
		transform.parent = null;
		Vector2 force = Vector2.down * 3.0f;
		force.x = Random.Range (-1f, 1f);

		rd.AddTorque (Random.Range (-5f, 5f));
		rd.AddForce (force, ForceMode2D.Force);
	}

	void Update()
	{
		if (Globals.dead || transform.position.y < -10.0)
			Destroy (this.gameObject);
	}

	public void Dest()
	{
		if (big) 
		{
			Instantiate (small, this.transform.position, this.transform.rotation);
			Instantiate (small, this.transform.position, this.transform.rotation);
		} 
		else
			Instantiate (explosion, this.transform.position, this.transform.rotation);

		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.GetComponent<PlayerCont>() != null)
		{
			Destroy (col.gameObject);
			Instantiate (explosion, col.transform);
			Globals.dead = true;
		}
	}
}
