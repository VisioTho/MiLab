using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoBonesController : MonoBehaviour
{

    public GeoTropismScriptableObject boneKinematics;
    public RaycastHitScriptableObject rayHit;
    public TreeRotateScriptableObject mouseStatus;

    private HingeJoint2D hingejoint;
    private Rigidbody2D rb2D;
    private RigidbodyType2D startingBodyType;
    private BoxCollider2D parentCollider;
    private Vector3 initialPosition;
    private JointMotor2D motor;
    public float motorSpeed = 100.0f;
    public float maxMotorTorque = 100.0f;
    private float thrust = 1f;
    private string boneName;

    private void Start()
    {
        boneName = gameObject.name;
        hingejoint = GetComponent<HingeJoint2D>();
        rb2D = GetComponent<Rigidbody2D>();
        startingBodyType = rb2D.bodyType;
      
    }

    private void OnEnable()
    {
    
        mouseStatus.treeClickedEvent.AddListener(MoveBone);

    }

    private void Update()
    {
        
        MoveBone(mouseStatus.mouseOn);
        
    }

    public void MoveBone(int _mouseOn)
    {
        if (_mouseOn == 3 && rayHit.rayName != null )
        {
            rb2D.bodyType = startingBodyType;
            if(rayHit.rayName == "DropPoint4")
            {
                
                
                rb2D.AddForce(transform.up * thrust);
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = 0;
                limits.max = 0;
                motor.motorSpeed = 1f;
                hingejoint.motor = motor;
                motor.maxMotorTorque = 1000f;
                hingejoint.limits = limits;
                hingejoint.motor = motor;
                Debug.Log(limits.max);
                //Invoke("SetKinematic", 5.0f);
                

            }else{
                
                Debug.Log("bones in motion");
                /*motor.motorSpeed = motorSpeed;
                motor.maxMotorTorque = maxMotorTorque;
                hingejoint.motor = motor; */
                float currentAngle = hingejoint.jointAngle;
                rb2D.AddForce(transform.up * thrust);
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = 0;
                limits.max = 40;
                motor.motorSpeed = 1f;
                motor.maxMotorTorque = 1000f;;
                hingejoint.motor = motor;
                hingejoint.limits = limits;
                hingejoint.motor = motor;
                Debug.Log(boneName +" my current angle is "+currentAngle);
            }
            
            
        }else if(_mouseOn != 3 && rayHit.rayName == null && boneKinematics.needsKinematic == true)
        {
            Debug.Log("Pausing Bone movement");
            rb2D.AddForce(transform.up * thrust);
            JointAngleLimits2D limits = hingejoint.limits;
            limits.min = 0;
            limits.max = 0;
            motor.motorSpeed = 1f;
            hingejoint.motor = motor;
            motor.maxMotorTorque = 1000f;
            hingejoint.limits = limits;
            hingejoint.motor = motor;

            if(hingejoint.limits.max == 0)
            {
                rb2D.bodyType = RigidbodyType2D.Static;
                Debug.Log("Rigid body reset");
            }
                
        }else{
                //rb2D.bodyType = startingBodyType;
                Debug.Log("HEY");
        }

        
        
    }


    public void SetKinematic()
        {
            if (rb2D.bodyType != RigidbodyType2D.Kinematic)
            {
                Debug.Log("body is now kinematic");
                rb2D.bodyType = RigidbodyType2D.Kinematic;
                //this._mouseOn = 4; // to jump us out if the function
                
            }
        }
}
