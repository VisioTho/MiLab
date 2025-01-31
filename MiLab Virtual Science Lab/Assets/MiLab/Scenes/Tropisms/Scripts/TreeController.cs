using System.Collections;
using System.Collections.Generic;

using UnityEngine;



///<summary>
/// Subscribes tyo the bones scriptable object for the direction variable change
/// recieves this change and sends it to the changeDirection Method
/// changeDirection method responds accordingly
///</summary>
public class TreeController : MonoBehaviour
{
    public bonesScriptableObject bonescriptableobject;
    private float motionSpeed;

    HingeJoint2D hingejoint;
    JointMotor2D motor;
    private Rigidbody2D rb2D;
    private float thrust = 1f;
    private float prevSpeed;


    void Start()
    {
        initializeObject();
    }

    private void OnEnable()
    {
        bonescriptableobject.moveChangeEvent.AddListener(changeDirection);
    }

    void Update()
    {
        changeDirection(bonescriptableobject.direction);

    }


    public void changeDirection(int direction)
    {
        
        switch (direction)
            {
                case 1:
                    DirectionLeft();
                    break;
                case 2:
                    DirectionCenter();
                    break;
                
                case 3:
                    DirectionRight();
                    break;
              
                default:
                    DirectionCenter();
                    break;
            }

    }

    private void DirectionLeft()
    {

        Debug.Log("Event Received");
            prevSpeed = -1;
            //rb2D.AddForce(transform.up * thrust);
            rb2D.velocity = transform.up * thrust * Time.deltaTime;
            JointAngleLimits2D limits = hingejoint.limits;
            limits.min = -16;
            limits.max = 16;
            motor.motorSpeed = -1f;
            hingejoint.motor = motor;
            motor.maxMotorTorque = 1000f;
            hingejoint.limits = limits;
            hingejoint.motor = motor;
    }

    public void DirectionRight()
    {
            prevSpeed = 1;
            //rb2D.AddForce(transform.up * thrust);
            rb2D.velocity = transform.up * thrust * Time.deltaTime;
            JointAngleLimits2D limits = hingejoint.limits;
            limits.min = -16;
            limits.max = 16;
            motor.motorSpeed = 1f;
            motor.maxMotorTorque = 1000f;
            hingejoint.motor = motor;
            hingejoint.limits = limits;
    }

    public void DirectionCenter()
    {
            if (prevSpeed == -1)
            {

                //rb2D.AddForce(transform.up * thrust);
                rb2D.velocity = transform.up * thrust * Time.deltaTime;
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = -16;
                limits.max = 0;
                motor.motorSpeed = 1f;
                motor.maxMotorTorque = 1000f;
                hingejoint.motor = motor;
                hingejoint.limits = limits;

            }
            else if (prevSpeed == 1)
            {

                //rb2D.AddForce(transform.up * thrust);
                rb2D.velocity = transform.up * thrust * Time.deltaTime;
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = 0;
                limits.max = 16;
                motor.motorSpeed = -1f;
                motor.maxMotorTorque = 1000f;
                hingejoint.motor = motor;
                hingejoint.limits = limits;
            }
    }

    public void initializeObject()
    {

        hingejoint = GetComponent<HingeJoint2D>();
        rb2D = GetComponent<Rigidbody2D>();

        JointAngleLimits2D limits = hingejoint.limits;
        limits.min = -1;
        limits.max = 1;
        motor.motorSpeed = 0f;
        hingejoint.motor = motor;
        motor.maxMotorTorque = 1000f;
        hingejoint.limits = limits;

        motor = hingejoint.motor;
        prevSpeed = 0;
    }
    

}
