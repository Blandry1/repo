using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1f; 
	public GameObject projectile;
	public float projectileSpeed = 5f;
	public float firingRate = 0.2f;
	public float health = 400f;
	
	public AudioClip fireSound;
	
	float xmin = -5f;
	float xmax = 5f;
	
	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)); 
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		//Input.mousePosition.x;					//class/method/field has type of Vector3
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage(); 
			missile.hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
	
	void fire() {
		Vector3 offset = new Vector3(0,1,0);
		GameObject beam =  Instantiate(projectile,transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed, 0); 
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {	
			InvokeRepeating("fire", 0.00001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("fire");
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;	
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;	
		}
		
		//restrict player to game space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
	}
}
