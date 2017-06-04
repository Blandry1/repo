using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour {

    public ScoreDisplay scoreDisplay;
    public Text scoreValue;
    

    public void Awake()
    {
        scoreDisplay = gameObject.AddComponent<ScoreDisplay>();     //AddComponent: adds script to gameObject. "gameObject" is a pre-instantiated variable in UnityEngine.
        //scoreDisplay = GetComponent<ScoreDisplay>();              //GetComponent: retrieves value from the GameObject.
        scoreValue.text = "Congrats on scoring: " + PlayerPrefs.GetString("score");
        Debug.Log(scoreValue.text);
    }

}
