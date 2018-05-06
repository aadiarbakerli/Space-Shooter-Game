using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
	public Rigidbody2D enemy;
	public Rigidbody2D small;
	public Rigidbody2D large;

	public int timer = 60;
	Vector2 spawn = new Vector2();
	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		if (!Globals.pause && !Globals.dead)
		{
			if (timer > 0)
				timer--;
			else {
				spawn.x = Random.Range (-3f, 3f);
				spawn.y = 10.5f;
				this.transform.position = spawn;

				float rand = Random.Range (0f, 3f);

				if (rand >= 0f && rand < 1f)
					Instantiate (enemy, transform);
				if (rand > 1f && rand < 2f)
					Instantiate (small, transform);
				if (rand > 2f && rand <= 3f)
					Instantiate (large, transform);

				timer = (30 / Globals.difficulty);
			}
		}
		if (Input.GetKeyDown ("space") && !Globals.dead && !Globals.main) 
		{
			if (Globals.pause) 
			{
				Time.timeScale = 1.0f;
				Globals.pause = false;
			} 
			else 
			{
				Time.timeScale = 0.0f;
				Globals.pause = true;
			}
		}
	}
}
