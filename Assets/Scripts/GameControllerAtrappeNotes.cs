using UnityEngine;
using System.Collections;

public class GameControllerAtrappeNotes : MonoBehaviour {

	public GameObject note;
	public GameObject fausse_note;
	public Vector3 spawnValues;
	public int noteCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText explanationText;
	public GUIText restartText;
	public int maxScore;
	public float endTime;

	private int rand;
	private int score;
	
	void Start()
	{
		restartText.text = "";
		explanationText.text = "Attrapez les notes pour marquer des points (5). \nAttention les rouges vous en font perdre ! (-20) \nAtteignez 100 points.";
		score = 0;
		UpdateScore ();

		Invoke ("Routine", 5);
	}

	void Routine() 
	{ 
		StartCoroutine ("spawnWaves"); 
		this.audio.Play ();
		explanationText.text = "";
	}
	
	void Update()
	{
		if (score == maxScore)
		{
			StopCoroutine ("spawnWaves");
			restartText.text = "Bravo vous avez gagné";
			PlayerPrefs.SetInt("tete", 1);
			Invoke("loadLevel", endTime);
		}
	}

	void loadLevel() { Application.LoadLevel ("MenuGuitare"); }

	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < noteCount; i++) 
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x) , spawnValues.y, spawnValues.z);
				rand = Random.Range (0, 5);
				if (rand == 0)
					Instantiate(fausse_note, spawnPosition, Quaternion.identity);
				else
					Instantiate(note, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
		
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		if (score < 0)
			score = 0;
		UpdateScore ();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
