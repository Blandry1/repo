using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public static int brickCount = 0;
	public AudioClip crack; 
	
	private LevelManager levelManager;
	public int maxHits;
	private int timesHit;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "breakable");
		
		if(isBreakable) {
			brickCount++;
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint	(crack, transform.position);
		if (isBreakable)
		HandleHits();
	}
		
	void HandleHits() {	
		timesHit++;
		if(timesHit >= maxHits) {
			brickCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject); 	 
		}
	}
	
	//TODO Remove this method once we can actually win
	void simulateWin() {
		levelManager.LoadNextLevel();
	}
}
 