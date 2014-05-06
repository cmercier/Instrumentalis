using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	private GameControllerAtrappeNotes gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerAtrappeNotes");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameControllerAtrappeNotes> ();
		if (gameControllerObject == null)
			Debug.Log ("Cannot find GameController script");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
			return;

		/*if (other.tag == "Note")
		{

		}*/

		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
