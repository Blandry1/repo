﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D trigger) {
		//print ("trigger");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose Screen");
		 
	}
	void OnCollisionEnter2D (Collision2D collision) {
		print ("collision");
	}
}  