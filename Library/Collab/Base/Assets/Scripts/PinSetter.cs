using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public GameObject pinSet;

    public bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    ActionMaster actionMaster = new ActionMaster();

    private Ball ball;
    private Animator animator;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
    }

    void Update () {
            standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            standingDisplay.color = Color.red;
            CheckStanding();
            
        }
    }

    public void RaisePins()
    {
         foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
                pin.RaiseIfStanding();
                pin.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
               
    }
   
    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
                pin.Lower();
        
    }
    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 1, 1829), Quaternion.identity);

    }  
  
    void CheckStanding()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 1f;
        if (Time.time - lastChangeTime > settleTime)
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log(action);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("dont know how to handle EndGame exception yet");
        }

        ball.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    public void SetBallOutOfPlay () {
        ballOutOfPlay = true;
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponentInParent<Pin>())
        {
            GameObject thingObjectParent = thingLeft.GetComponentInParent<Pin>().gameObject;
            Destroy(thingObjectParent);
        }
    }

    int CountStanding()
    {
        int CurrentPinsStanding = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
                CurrentPinsStanding++;
        }
        return CurrentPinsStanding;
    }

}
