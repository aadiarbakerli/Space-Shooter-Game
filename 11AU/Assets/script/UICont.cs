using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICont : MonoBehaviour 
{

	public Text txt;
	public Button easy;
	public Button med;
	public Button hard;

	public Rigidbody2D player;
	// Use this for initialization
	void Start () 
	{
		Globals.Score = 0;

		easy.onClick.AddListener (Easy);
		med.onClick.AddListener (Medium);
		hard.onClick.AddListener (Hard);
	}
	
	// Update is called once per frame
	void Update () 
	{
		txt.text = Globals.Score.ToString();

		if (Input.GetKeyDown ("escape") && Globals.main)
			Application.Quit();
		if (Input.GetKeyDown ("escape") && !Globals.main)
		{
			Globals.main = true;
			Globals.dead = true;
		}

		if (Globals.dead && Globals.main) 
		{
			easy.gameObject.SetActive (true);
			med.gameObject.SetActive (true);
			hard.gameObject.SetActive (true);
		}
	}

	public void Easy()
	{
		Globals.main = false;
		Globals.dead = false;
		Globals.Score = 0;
		Globals.difficulty = 1;

		easy.gameObject.SetActive (false);
		med.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);

		Instantiate (player);
	}

	public void Medium()
	{
		Globals.main = false;
		Globals.dead = false;
		Globals.Score = 0;
		Globals.difficulty = 2;

		easy.gameObject.SetActive (false);
		med.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);

		Instantiate (player);
	}

	public void Hard()
	{
		Globals.main = false;
		Globals.dead = false;
		Globals.Score = 0;
		Globals.difficulty = 3;

		easy.gameObject.SetActive (false);
		med.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);

		Instantiate (player);
	}
}

public static class Globals
{
	public static int Score = 0;
	public static int difficulty = 1;
	public static bool pause = false;
	public static bool dead = true;
	public static bool main = true;
}
