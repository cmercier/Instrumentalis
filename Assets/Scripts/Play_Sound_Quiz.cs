using UnityEngine;
using System.Collections;

public class Play_Sound_Quiz : MonoBehaviour {

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
		audio.Play ();
	}
}
