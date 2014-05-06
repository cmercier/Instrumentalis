using UnityEngine;
using System.Collections;

public class Test_Reponse : MonoBehaviour {
	
	private GameControllerQuiz gameController;
	public 
		
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