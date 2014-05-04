﻿using UnityEngine;
using System.Collections;

public class Start_Game_Trigger : MonoBehaviour {

	private GameControllerTutoQuiz gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerTutoQuiz");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameControllerTutoQuiz>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnMouseDown ()
	{
		gameController.lancer_jeu ();
	}
}
