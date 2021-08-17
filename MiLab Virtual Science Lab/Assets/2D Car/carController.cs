using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

/*--------------------------------------------------------------------
                            Script Summary 
        This script is a modified version of the original version from the
		 '2D car' Free Asset from the asset store developed by Joao Ramiro
		 https://assetstore.unity.com/packages/tools/physics/2d-car-73763

		 The script controls movement of a 2D car object in either forward 
		 or backward direction. Input for movement is obtained via the 
		 UserInputController.cs script via static variables. 
    ------------------------------------------------------------------------                 
                                                                        */


	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;

	JointMotor2D motorFront;

	JointMotor2D motorBack;

	public float speedF;
	public float speedB;

	public float torqueF;
	public float torqueB;


	public bool TractionFront = true;
	public bool TractionBack = true;


	public float carRotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void Update () {
	
		if (UserInputController.isForward) {


			if (TractionFront) {
				motorFront.motorSpeed = speedF * -1;
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedF * -1;
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;

			}

		} else if (UserInputController.isBackward) {

		//	Input.GetAxisRaw ("Vertical") < 0
			if (TractionFront) {
				motorFront.motorSpeed = speedB * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedB * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;

			}

		} else if(UserInputController.isDiscelerating) {

			backwheel.useMotor = false;
			frontwheel.useMotor = false;

		}




		if (Input.GetAxisRaw ("Horizontal") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

		}

	}
}
