using UnityEngine;
using System.Collections;

public class BoutonMenu : MonoBehaviour {
	
	void OnMouseEnter() {
		renderer.enabled = true;
	}

	void OnMouseExit() {
		renderer.enabled = false;
	}

	void OnMouseDown() {
		Application.LoadLevel ("Simon");
	}
	
}
