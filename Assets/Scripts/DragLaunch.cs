using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    private Ball ball;
    private Vector3 lastPos, startPos;
    private float endTime, startTime;
    private float nudge;
   

    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();
    }
    public void DragStart()
    //capture time and position of drag start
    {
        if (!ball.inPlay)
        {
            startPos = Input.mousePosition;
            startTime = Time.time;
        } 
    }

    public void BallClamp ()
    {
      //  Mathf.Clamp();
    }
    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void DragEnd()
       //Launch Ball
    {
        if (!ball.inPlay)
        {
            lastPos = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;
            float launchSpeedX = (lastPos.x - startPos.x) / dragDuration;
            float launchSpeedZ = (lastPos.y - startPos.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

            ball.Launch(launchVelocity);
        }
    }
}
