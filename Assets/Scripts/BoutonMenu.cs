using UnityEngine;
using System.Collections;

public class BoutonMenu : MonoBehaviour {
	public string ToLoad;
	
	void OnMouseEnter() {
		if(PlayerPrefs.GetInt(ToLoad)<2)
		{
			renderer.enabled = true;
			audio.Play ();
		} 
		else
			renderer.enabled = true;
	}

	void OnMouseExit() {
		if(PlayerPrefs.GetInt(ToLoad)<2)
		{
			renderer.enabled = false;
			audio.Stop ();
		} 
		else
			renderer.enabled = true;
	}

	void OnMouseDown() {
		if(PlayerPrefs.GetInt(ToLoad)<2)
			Application.LoadLevel (ToLoad);
	}
}
