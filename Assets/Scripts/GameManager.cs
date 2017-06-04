using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();
    private ScoreDisplay scoreDisplay;
    private PinSetter pinSetter;
    private Ball ball;

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl (int pinFall)
    {
        rolls.Add(pinFall);
        ball.Reset();
       
        pinSetter.PerformAction(ActionMaster.NextAction(rolls));
        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.Fillframes(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("Error in bowls()");
        }
    }
    public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Bowl(0);
        }
    }
}
