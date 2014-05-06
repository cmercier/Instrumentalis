using UnityEngine;
using System.Collections;

public class BoutonMenu : MonoBehaviour {
	
	void OnMouseEnter() {
		renderer.enabled = true;
		audio.Play ();
	}

	void OnMouseExit() {
		renderer.enabled = false;
		audio.Stop ();
	}

	void OnMouseDown() {
		Application.LoadLevel ("Simon");
	}
	
}
