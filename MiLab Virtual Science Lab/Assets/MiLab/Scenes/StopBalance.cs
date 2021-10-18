using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBalance : MonoBehaviour
{
    HingeJoint2D hinge;
    public GameObject leftHand, rightHand;
    private void Start()
    {
        hinge = gameObject.GetComponent<HingeJoint2D>();
    }
    private void Update()
    {
        
        if (hinge.jointAngle < -14)
            leftHand.SetActive(true);
        else
            leftHand.SetActive(false);

        if (hinge.jointAngle > 13)

            rightHand.SetActive(true);

        else
            rightHand.SetActive(false);
    }
}
