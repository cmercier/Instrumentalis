using UnityEngine;
using System.Collections;

public class BoutonMenu : MonoBehaviour {
	public string ToLoad;
	public string elementName;

	void Start()
	{
		if (PlayerPrefs.GetInt("manche") == 1 && PlayerPrefs.GetInt("corps") == 1 && PlayerPrefs.GetInt("tete") == 1)
		    PlayerPrefs.SetInt("guitare", 1);

		if (PlayerPrefs.GetInt(elementName) == 1)
			renderer.enabled = true;
	}
	
	void OnMouseEnter() {
		if(true /*PlayerPrefs.GetInt(ToLoad)<2 && PlayerPrefs.GetInt(elementName) != 1*/)
		{
			renderer.enabled = true;
			audio.Play ();
		} 

	}

	void OnMouseExit() {
		if(PlayerPrefs.GetInt(ToLoad)<2 && PlayerPrefs.GetInt(elementName) != 1)
			renderer.enabled = false;
		else
			renderer.enabled = true;

		audio.Stop ();
	}

	void OnMouseDown() {
		if(PlayerPrefs.GetInt(ToLoad)<2)
			Application.LoadLevel (ToLoad);
	}
}
