using UnityEngine;
using System.Collections;
using System;

public class GameControllerTutoQuiz : MonoBehaviour {

	public GUIText affichage;
	public GUIText nom_effet;
	
	public AudioClip[] effets_son;

	int numEffet = 0;

	private String[] effets_texte;
	
	private AudioSource audioPlayer;
	
	public GameControllerTutoQuiz()
	{
		effets_texte = new String[]{"Clean","Delay","Distortion","Echo", "Flanger", "Filtre Passe Bas", "Filtre Passe Haut", "Phaser", "Tremolo", "Tubevox"};
	}
	
	void Start(){
		affichage.text = "Découvrer des effets de guitare avant de répondre au quiz" + "Effets : " + (numEffet+1) + "/" + effets_texte.Length;
		nom_effet.text = effets_texte [numEffet];

		GameObject audioPlayerObject = GameObject.FindWithTag ("AudioPlayer");
		if (audioPlayerObject != null)
		{
			audioPlayer = audioPlayerObject.GetComponent <AudioSource>();
		}
		if (audioPlayer == null)
		{
			Debug.Log ("Cannot find 'AudioPlayer' script");
		}
		
		audioPlayer.clip = effets_son [numEffet];
		audioPlayer.Play ();
	}
	
	public void precedent()
	{
		if(numEffet > 0)
		{
			numEffet--;
			audioPlayer.clip = effets_son[numEffet];
			nom_effet.text = effets_texte [numEffet];
			affichage.text = "Effets : " + (numEffet+1) + "/" + effets_texte.Length;
			audioPlayer.PlayDelayed((float)0.5);
		}
		else
		{
			affichage.text = "Vous etes déjà au début. " + "Effets : " + (numEffet+1) + "/" + effets_texte.Length;
		}
	}

	public void suivant()
	{
		if(numEffet < (effets_texte.Length-1))
		{
			numEffet++;
			audioPlayer.clip = effets_son[numEffet];
			nom_effet.text = effets_texte [numEffet];
			affichage.text = "Effets : " + (numEffet+1) + "/" + effets_texte.Length;
			audioPlayer.PlayDelayed((float)0.5);
		}
		else
		{
			affichage.text = "Vous etes déjà à la fin. " + "Effets : " + (numEffet+1) + "/" + effets_texte.Length;
		}
	}

	public void lancer_jeu()
	{
		Application.LoadLevel ("Quiz_Effets");
	}

}
