using UnityEngine;
using System.Collections;
using System;

public class GameControllerQuiz : MonoBehaviour {

	public GUIText affichage;
	public GUIText[] propositions;
	
	private String[] effets_texte;
	public AudioClip[] effets_son;
	
	private int solution;
	private int nbreQuestions = 4;
	private int numQuestion = 0;
	private int nbreEffets;
	
	private AudioSource audioPlayer;

	System.Random random = new System.Random();

	ArrayList alreadyAsked = new ArrayList();
	
	public GameControllerQuiz()
	{
		effets_texte = new String[]{"Clean","Delay","Distortion","Echo", "Flanger", "Filtre Passe Bas", "Filtre Passe Haut", "Phaser", "Tremolo", "Tubevox"};
		nbreEffets = effets_texte.Length;
	}
	
	void Start(){
		affichage.text = "Vous allez devoir deviner le nom de l'effet";
		solution = tirageAleatoire (0, nbreEffets);
		alreadyAsked.Add (solution);
		remplirChoix ();
		
		GameObject audioPlayerObject = GameObject.FindWithTag ("AudioPlayer");
		if (audioPlayerObject != null)
		{
			audioPlayer = audioPlayerObject.GetComponent <AudioSource>();
		}
		if (audioPlayer == null)
		{
			Debug.Log ("Cannot find 'AudioPlayer' script");
		}
		
		audioPlayer.clip = effets_son [solution];
		audioPlayer.Play ();
	}

	public void testerChoix (string Choix)
	{
		int choix = getChoix (Choix);
		if(choix == solution)
		{
			affichage.text = "Bien joué ";
			numQuestion++;

			if (numQuestion == nbreQuestions)
			{
				affichage.text = "Vous avez fini le quiz";
				Application.LoadLevel("MenuGuitare");
				numQuestion = 0;
				alreadyAsked.Clear();
			}

			do 
				solution = tirageAleatoire(0, nbreEffets);
			while(alreadyAsked.Contains(solution)); 
			alreadyAsked.Add(solution);

			remplirChoix();
			audioPlayer.clip = effets_son [solution];
			audioPlayer.PlayDelayed((float)0.5);

		}
		else
		{
			affichage.text = "Erreur, veuillez recommencer";
		}
	}

	void remplirChoix()
	{
		ArrayList alreadyFilled = new ArrayList();
		alreadyFilled.Add (solution);
		int solutionPlace = tirageAleatoire(0, nbreQuestions);
		int rand;

		// On ajoute la solution dans un des 4
		propositions [solutionPlace].text = effets_texte [solution];

		// On remplit le reste
		for(int i = 0; i < nbreQuestions; i++)
		{
			if (i != solutionPlace)
			{
				do 
					rand = tirageAleatoire(0, nbreEffets); 
				while(alreadyFilled.Contains(rand)); 

				propositions[i].text = effets_texte[rand];
				alreadyFilled.Add(rand);
			}
		}
	}

	int tirageAleatoire(int min, int max)
	{
		int randomNumber = random.Next(min, max);
		return randomNumber;
	}

	int getChoix(string choix)
	{
		for(int i = 0; i < nbreEffets; i++)
		{
			if (effets_texte[i] == choix)
				return i;
		}
		return -1;
	}
}
