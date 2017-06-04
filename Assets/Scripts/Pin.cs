using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    private float standingThreshold = 3f;
    public float distToRaise = 40f;
    private Rigidbody rigidBody;


    void Start() //fixes the NullExpcetionError
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = this.transform.rotation.eulerAngles;
        float tiltInX = (rotationInEuler.x < 180f) ? rotationInEuler.x : 360 - rotationInEuler.x;
        float tiltInZ = (rotationInEuler.z < 180f) ? rotationInEuler.z : 360 - rotationInEuler.z;
       
        if ((tiltInX < standingThreshold) && (tiltInZ < standingThreshold))
            
            return true;
        else
            return false;
    }

    public void RaiseIfStanding()
    {
        if (IsStanding()) {
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
        }
    }

    public void Lower()
    {   
        transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;

    }
    

}
