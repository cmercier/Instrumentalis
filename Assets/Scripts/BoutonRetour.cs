﻿using UnityEngine;
using System.Collections;

public class BoutonRetour : MonoBehaviour {

	public string ToLoad = "Menu_Principal";

	void OnMouseDown()
	{
		Application.LoadLevel (ToLoad);
		/*if(PlayerPrefs.GetInt(ToLoad)<2)
			PlayerPrefs.SetInt (ToLoad, 1);*/
	}

}
