using UnityEngine;
using System.Collections;

public class BoutonMenu : MonoBehaviour {
	public string ToLoad;
	private bool done=false;
	
	void OnMouseEnter() {
		if (!done) {
						renderer.enabled = true;
						audio.Play ();
				} else
						renderer.enabled = true;
	}

	void OnMouseExit() {
		if (!done) {
						renderer.enabled = false;
						audio.Stop ();
				} else
						renderer.enabled = true;
	}

	void OnMouseDown() {
		if(!done)
			Application.LoadLevel (ToLoad);
	}

	public void setDoneTrue()
	{
		done = true;
	}
	
}
