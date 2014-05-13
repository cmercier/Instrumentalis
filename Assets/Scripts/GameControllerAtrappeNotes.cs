using UnityEngine;
using System.Collections;

public class GameControllerAtrappeNotes : MonoBehaviour {

	public GameObject note;
	public Vector3 spawnValues;
	public int noteCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	
	private int score;
	
	void Start()
	{
		restartText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnWaves());
	}
	
	void Update()
	{
		if (score == 50)
		{
			restartText.text = "Bravo vous avez gagné";
			Application.LoadLevel ("MenuGuitare");
		}

	}
	
	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < noteCount; i++) 
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x) , spawnValues.y, spawnValues.z);
				Instantiate(note, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
		
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
