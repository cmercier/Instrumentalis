using UnityEngine;
using System.Collections;

public class Explication : MonoBehaviour {

	public GameObject parent;
	void OnMouseDown()
	{
				parent.SetActive(false);
	}
}
