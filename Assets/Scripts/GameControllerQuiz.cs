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
	
	private AudioSource audioPlayer;

	System.Random random = new System.Random();

	ArrayList alreadyAsked = new ArrayList();
	
	public GameControllerQuiz()
	{
		effets_texte = new String[]{"Delay","Filtre Pass Haut", "Filtre Pass Bas", "effet 4", "effet 5"};
	}
	
	void Start(){
		affichage.text = "Vous allez devoir deviner le nom de l'effet";
		solution = tirageAleatoire (0, 4+1);
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
	}

	public void testerChoix (string Choix)
	{
		int choix = getChoix (Choix);
		if(choix == solution)
		{
			affichage.text = "Bien joué ";
			numQuestion++;

			do 
				solution = tirageAleatoire(0, 4+1);
			while(alreadyAsked.IndexOf(solution) != -1); 
			alreadyAsked.Add(solution);

			remplirChoix();
			audioPlayer.clip = effets_son [solution];
			if (numQuestion == nbreQuestions)
			{
				affichage.text = "Vous avez fini le quiz";
				numQuestion = 0;
				alreadyAsked.Clear();
			}
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
		int solutionPlace = tirageAleatoire(0, 4);
		int rand;

		// On ajoute la solution dans un des 4
		propositions [solutionPlace].text = effets_texte [solution];

		// On remplit le reste
		for(int i = 0; i < 4; i++)
		{
			if (i != solutionPlace)
			{
				do 
					rand = tirageAleatoire(0, 5); 
				while(alreadyFilled.IndexOf(rand) != -1); 

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
		for(int i = 0; i < effets_texte.Length; i++)
		{
			if (effets_texte[i] == choix)
				return i;
		}
		return -1;
	}
}
