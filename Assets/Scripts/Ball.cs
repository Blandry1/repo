using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

   // public Vector3 launchVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    public bool inPlay = false;
    private Vector3 ballStartPos;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = false;
        //Launch(launchVelocity);

        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity) {
        inPlay = true;
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;
        audioSource.Play();
       
	}

    public void Reset()
    {
            inPlay = false;
            transform.position = ballStartPos;
            transform.rotation = Quaternion.identity;
            rigidBody.useGravity = false;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
    }
}
