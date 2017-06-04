using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	int max;
	int min;
	int guess;
	
	public int maxGuessesAllowed = 5;
	public Text text; //public type variable
	
	void Start () {
		StartGame();	
	}
	
	void StartGame() {
		 max = 1000;
		 min = 1;
		 NextGuess();
		
		max = max + 1;
	}

	public void GuessHigher () {
		min = guess;
		NextGuess ();
	}
	public void GuessLower () {
		max = guess;
		NextGuess();
	}
	
	void NextGuess () {	
		guess = Random.Range (min, max+1);
		text.text = guess.ToString();  //variable.attribute
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if (maxGuessesAllowed < 1)
			Application.LoadLevel("Win");
	}
}
