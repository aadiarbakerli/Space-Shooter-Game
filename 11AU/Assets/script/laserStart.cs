using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserStart : MonoBehaviour 
{
	public bool enemy = false;

	public Transform hit;
	public Transform exp;
	public AudioSource pew;

	private int timer = 90;
	// Use this for initialization
	void Start () 
	{
		transform.parent = null;
		pew.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Globals.pause)
		{
			if (timer > 0)
				timer--;
			else
				Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (enemy && (col.gameObject.GetComponent<PlayerCont>() != null)) 
		{
			Globals.dead = true;
			Destroy (col.gameObject);
			Instantiate (exp, col.transform);
			Instantiate (hit, transform);
			Destroy (this.gameObject);
		}
		else if (!enemy && (string.Compare (col.name, "Enemy(Clone)") == 0))
		{
			Globals.Score += (100 * Globals.difficulty);
			Destroy (col.gameObject);
			Instantiate (exp, col.transform);
			Instantiate (hit, transform);
			Destroy (this.gameObject);
		} 
		else if(!enemy && (col.gameObject.GetComponent<PlayerCont>() == null)) 
		{
			Instantiate (hit, this.transform.position, this.transform.rotation);

			AstCont ast = col.GetComponent (typeof(AstCont)) as AstCont;

			if (ast != null)
			{
				ast.hp--;

				if (ast.hp <= 0) {
					Globals.Score += (200 * Globals.difficulty);
					ast.Dest ();
				}
				Destroy (this.gameObject);
			}
		}
	}
}
