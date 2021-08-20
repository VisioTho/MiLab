using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

/*--------------------------------------------------------------------
                            Script Summary 
        This script is a modified version of the original version from the
		 '2D car' Free Asset from the asset store developed by Joao Ramiro
		 https://assetstore.unity.com/packages/tools/physics/2d-car-73763

		 The script controls movement of the 2D car by using scripted states of motion (moving
		 forward, backwards or decelerating) to change speed and direction.
    ------------------------------------------------------------------------*/             
                                                                        
	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;

	JointMotor2D motorFront; //front wheel of car

	JointMotor2D motorBack; //back wheel of car

	public float speedF; //speed in drive
	public float speedB; //speed in reverse

	public float torqueF; //torque front wheel
	public float torqueB; //torque back wheel


	public bool TractionFront = true; 
	public bool TractionBack = true;


	public float carRotationSpeed;

	#region //change state of car motion 
	//state of the car                                                                 
 	private bool isForward, isBackward, isDiscelerating, isStopped;

  	//move the car forward
	public void moveforward()
  	{
      //update state of the car
      isForward = true;
      isBackward = false;
      isDiscelerating = false;
      isStopped = false;
  	}

  	//move the car backwards
  	public void moveBackward()
  	{
      //update state of the car
      isForward = false;
      isBackward = true;
      isDiscelerating = false;
      isStopped = false;
  	}

  	//stop the car
  	public void stop()
  	{
      isStopped=true;
      isDiscelerating = true;
      isForward = false;
      isBackward = false;
  	}

  	//discelerate the car 
  	public void discelerate()
  	{
      //update state of the car
      isDiscelerating = true;
      isForward = false;
      isBackward = false;
      isStopped = false;
  	}
  #endregion
	
	// Update is called once per frame
	void Update () {
	#region //control movement of car based on state
	//move the car forward if state changes to forward (as determined by input buttons)
		if (isForward) {

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
	//move the car in reverse if state changes to backwards (as determined by input buttons)
		} else if (isBackward) {

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
	// decelerate the car if state changes to decelerating
		} else if(isDiscelerating) {

			backwheel.useMotor = false;
			frontwheel.useMotor = false;

		} else if(isStopped) {
			
			if (TractionFront) {
				motorFront.motorSpeed = 0 * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = 0 * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;
			}
		}




		if (Input.GetAxisRaw ("Horizontal") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

		}
		#endregion
	}
}