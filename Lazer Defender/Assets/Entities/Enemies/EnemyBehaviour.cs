using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed = 5f; 
	public float health = 150f;
	public float shotsPerSeconds = 0.5f;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	public int ScoreValue = 150;
	private ScoreKeeper scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage(); 
			missile.hit();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	void Die() {
		Destroy(gameObject);
		scoreKeeper.Score(ScoreValue);
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
	}
	
	void Update() {
		float probability = Time.deltaTime  * shotsPerSeconds;
		if(Random.value < probability) {
			Fire ();
		}
	}
	
	void Fire() {
		GameObject beam =  Instantiate(projectile,transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileSpeed, 0); 
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
}  