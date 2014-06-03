using UnityEngine;
using System.Collections;

public class Explication : MonoBehaviour {

	public GameObject parent;
	public string nomScene;

	void Start()
	{
		if(PlayerPrefs.GetInt(nomScene)==0)
			parent.SetActive(true);
		else
			parent.SetActive(false);
	}

	void OnMouseDown()
	{
		parent.SetActive(false);
		PlayerPrefs.SetInt (nomScene, 1);
	}

}
