﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load resquested for: " + name);
        SceneManager.LoadScene(name);
	}		
	public void QuitRequest() {
		Debug.Log("I want to quit!");
		Application.Quit();
	}
}
 