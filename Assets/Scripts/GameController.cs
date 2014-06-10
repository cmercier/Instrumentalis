using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText affichage;

	public AudioClip[] musiques;
	public AudioClip musique_fin;

	int curseur = 0;
	int numSeq = 0;

	int[] seq1;
	int[] seq2;
	int[] seq3;
	int[] seq4;
	int[][] sequences;

	private AudioSource audioPlayer;

	private bool end = false;

	public GameController()
	{
		seq1 = new int[]{1, 2, 3};
		seq2 = new int[]{4, 5, 3};
		seq3 = new int[]{1, 2, 3, 5, 2, 1};
		seq4 = new int[]{1, 2, 3, 4, 5, 3, 1, 2, 3, 5, 2, 1};
		sequences = new int[][]{seq1, seq2, seq3, seq4};
	}

	void Start(){
		affichage.text = "Vous allez devoir exercer votre oreille, reproduisez les différentes séquences";

		GameObject audioPlayerObject = GameObject.FindWithTag ("AudioPlayer");
		if (audioPlayerObject != null)
		{
			audioPlayer = audioPlayerObject.GetComponent <AudioSource>();
		}
		if (audioPlayer == null)
		{
			Debug.Log ("Cannot find 'AudioPlayer' script");
		}

		audioPlayer.clip = musiques [numSeq];
		audioPlayer.Play();
	}

	void Update() 
	{
		if (end == true && !this.audio.isPlaying && !audioPlayer.audio.isPlaying)
		{
			PlayerPrefs.SetInt("manche",1);
			Application.LoadLevel ("MenuGuitare");
		}
	}

	public void testerProgression(string Note)
	{
		if (end)
			return;

		int note = getNote (Note);
		affichage.text = (curseur+1) + "/" + sequences[0].Length;
		if(sequences[numSeq][curseur] == note)
		{
			affichage.text = "Bien joué " + (curseur+1) + "/" + sequences[numSeq].Length;
			curseur++;
			if(curseur == sequences[numSeq].Length){
				affichage.text = "Félicitation, vous pouvez passez à la séquence suivante";
				curseur = 0;
				numSeq++;
				if(numSeq == sequences.Length) // Si tout est fini, on obtient la partie de l'instrument
				{
					affichage.text = "Félicitation, vous avez fini le mini-jeu, attendez la fin de la musique";
					end = true;
					this.audio.PlayDelayed((float)0.365);
					Invoke("desactivateButtons", (float)0.365);
					return;
				}
				audioPlayer.clip = musiques [numSeq];
				audioPlayer.PlayDelayed((float)0.5);
			}
		}
		else
		{
			curseur = 0;
			affichage.text = "Erreur, veuillez recommencer la séquence";
		}
	}

	void desactivateButtons()
	{
		GameObject[] Notes = GameObject.FindGameObjectsWithTag ("Note");
		if (Notes != null)
		{
			foreach(GameObject n in Notes)
			{
				AudioSource m = n.GetComponent<AudioSource>();
				m.enabled = false;
			}
		}
		if (audioPlayer == null)
		{
			Debug.Log ("Cannot find 'Notes' script");
		}

		audioPlayer.audio.enabled = false;
	}

	int getNote(string note)
	{
		switch (note) {
		case "Note 1":
			return 1;
		case "Note 2":
			return 2;
		case "Note 3":
			return 3;
		case "Note 4":
			return 4;
		case "Note 5":
			return 5;
		default:
			return 0;
		}
	}
}
