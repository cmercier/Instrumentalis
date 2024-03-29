﻿using UnityEngine;
using System.Collections;

public class Play_Sound : MonoBehaviour {

	private GameController gameController;
	public KeyCode key;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnMouseDown ()
	{
		audio.Play ();
		if (this.CompareTag("Note"))
		    gameController.testerProgression (this.name);
	}

	void Update()
	{
		if (Input.anyKeyDown)
			if (Input.GetKeyDown (key)) 
			{
					audio.Play ();
					if (this.CompareTag ("Note"))
							gameController.testerProgression (this.name);
			}
	}
}
