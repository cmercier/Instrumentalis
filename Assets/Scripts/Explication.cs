using UnityEngine;
using System.Collections;

public class Explication : MonoBehaviour {

	public GameObject parent;
	public LayerMask duringLayer;
	public LayerMask afterLayer;
	public string nomScene;
	private GameObject[] instruments;

	void Awake()
	{
		instruments = GameObject.FindGameObjectsWithTag ("ToActivate");
		foreach(GameObject i in instruments)
		{
			i.layer = duringLayer;
		}
	}
	void Start()
	{
		if(PlayerPrefs.GetInt(nomScene) == 0)
			parent.SetActive(true);
		else
			parent.SetActive(false);
	}

	void OnMouseDown()
	{
		parent.SetActive(false);
		PlayerPrefs.SetInt (nomScene, 1);

		foreach(GameObject i in instruments)
		{
			i.layer = afterLayer;
		}
	}

}
