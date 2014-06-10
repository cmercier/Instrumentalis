using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	private GameControllerAtrappeNotes gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerAtrappeNotes");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameControllerAtrappeNotes> ();
		if (gameControllerObject == null)
			Debug.Log ("Cannot find GameController script");
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Fausse_Note")
						return;

		gameController.audio.mute = true;
		Destroy(other.gameObject);
	}
}
