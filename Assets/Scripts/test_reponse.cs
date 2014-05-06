using UnityEngine;
using System.Collections;

public class test_reponse : MonoBehaviour {

	private GameControllerQuiz gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerQuiz");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameControllerQuiz>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnMouseDown ()
	{
		gameController.testerChoix (this.GetComponentsInChildren<GUIText>()[0].text);
	}
}
