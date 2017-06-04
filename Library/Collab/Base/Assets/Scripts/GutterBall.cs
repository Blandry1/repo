using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GutterBall : MonoBehaviour
{

    private PinSetter pinSetter;
    private Ball ball;

    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            pinSetter.SetBallOutOfPlay();
        }

    }

}
