using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;	//to pass vector position around
    private Rigidbody2D rigidBody2D;
    private AudioSource sound;
	
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();   //attaching paddle in hiarchy to paddle object
														//generic, looking for type Paddle
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//transform = position in world space
	}
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range (0f, 0.2f));
		
		if(hasStarted) {
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
		
	}
	
	void Update () { 
		if(!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			if((Input.GetMouseButton(0))) {
				print ("Mouse Clicked");
				hasStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
