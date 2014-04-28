using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText affichage;

	public AudioClip[] musiques;

	int curseur = 0;
	int numSeq = 0;

	int[] seq1;
	int[] seq2;
	int[] seq3;
	int[] seq4;
	int[][] sequences;

	private AudioSource audioPlayer;

	public GameController()
	{
		seq1 = new int[]{1, 2, 3};
		seq2 = new int[]{4, 5, 3};
		seq3 = new int[]{1, 2, 3, 5, 2, 1};
		seq4 = new int[]{1, 2, 3, 4, 5, 3, 1, 2, 3, 5, 2, 1};
		sequences = new int[][]{seq1, seq2, seq3, seq4};
	}

	void Start(){
		affichage.text = "Vous pouvez commencer";

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
	}

	public void testerProgression(string Note)
	{
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
				if(numSeq == sequences.Length)
					numSeq = 0;
				audioPlayer.clip = musiques [numSeq];
			}
		}
		else
		{
			curseur = 0;
			affichage.text = "Erreur, veuillez recommencer la séquence";
		}

	}

	int getNote(string note)
	{
		switch (note) {
		case "Note 1":
			return 1;
			break;
		case "Note 2":
			return 2;
			break;
		case "Note 3":
			return 3;
			break;
		case "Note 4":
			return 4;
			break;
		case "Note 5":
			return 5;
			break;
		default:
			return 0;
			break;
		}
	}
}
