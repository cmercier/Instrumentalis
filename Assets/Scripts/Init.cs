using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	
	public string[] TabScenes;
	// Use this for initialization
	void Start () 
	{
		for(int i=0;i<TabScenes.Length;i++)
			PlayerPrefs.SetInt(TabScenes[i],0);
		Application.LoadLevel("Menu_Principal");	
	}
	
}