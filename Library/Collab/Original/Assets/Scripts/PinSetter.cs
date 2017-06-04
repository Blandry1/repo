using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;
    private PinCounter pinCounter;
   

    ActionMaster actionMaster = new ActionMaster();

    private Ball ball;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    void Update () {
           
    }

    public void RaisePins()
    {
         foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
                pin.RaiseIfStanding();
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
  
    public void PerformAction (ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("dont know how to handle EndGame exception yet");
        }
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

   

}
