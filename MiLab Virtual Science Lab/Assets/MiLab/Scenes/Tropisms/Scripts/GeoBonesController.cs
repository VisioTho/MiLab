using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    private GameObject plant; 
    private BoxCollider2D collider; 
    private BoxCollider2D boneCollider; 
    private Vector3 targetPosition ; 
    private bool reset ; 
    private GameObject autoDropPoint;
    private GameObject DropPoint1;
    private GameObject DropPoint2;
    private GameObject DropPoint3;
    private Vector3 startingPosition;

    private void Start()
    {
        plant = GameObject.Find("Geotropism_plant");
        DropPoint1 = GameObject.Find("DropPoint1");
        DropPoint2 = GameObject.Find("DropPoint2");
        DropPoint3 = GameObject.Find("DropPoint3");
        plant = GameObject.Find("Geotropism_plant");
        startingPosition = plant.transform.position;
        collider = plant.GetComponent<BoxCollider2D>();
        boneName = gameObject.name;
        boneCollider = gameObject.GetComponent<BoxCollider2D>();
        hingejoint = GetComponent<HingeJoint2D>();
        rb2D = GetComponent<Rigidbody2D>();
        startingBodyType = rb2D.bodyType;
        targetPosition = new Vector3(collider.transform.position.x, plant.transform.position.y, 0.976f);
        reset = false;
      
    }

    private void OnEnable()
    {
        mouseStatus.treeClickedEvent.AddListener(MoveBone);
        mouseStatus.treeClickedEvent.AddListener(rotateToRestPoint);
    }

    public void MoveBone(int _mouseOn)
    {
        if (_mouseOn == 3 && rayHit.rayName != null )
        {
            rb2D.bodyType = startingBodyType;
            if(rayHit.rayName == "DropPoint4")
            {
                DropPointsTurnON();
                //colliderSwitchON();
                rb2D.velocity = transform.up * thrust * Time.deltaTime;
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = 0;
                limits.max = 0;
                motor.motorSpeed = 1f;
                hingejoint.motor = motor;
                motor.maxMotorTorque = 1000f;
                hingejoint.limits = limits;
                hingejoint.motor = motor;
                

            }else if( rayHit.rayName == "DropPoint5")
            {
                colliderSwitchOFF();
                Debug.Log("bones in motion");
                float currentAngle = hingejoint.jointAngle;
                rb2D.velocity = transform.up * thrust * Time.deltaTime;
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = -25;
                limits.max = 0;
                motor.motorSpeed = 1f;
                motor.maxMotorTorque = 1000f;
                hingejoint.motor = motor;
                hingejoint.limits = limits;
                hingejoint.motor = motor;
            }else{

                colliderSwitchOFF();
                Debug.Log("bones in motion");
                float currentAngle = hingejoint.jointAngle;
                rb2D.velocity = transform.up * thrust * Time.deltaTime;
                JointAngleLimits2D limits = hingejoint.limits;
                limits.min = 0;
                limits.max = 25;
                motor.motorSpeed = 1f;
                motor.maxMotorTorque = 1000f;;
                hingejoint.motor = motor;
                hingejoint.limits = limits;
                hingejoint.motor = motor;

                
            }
            
            
        }else if(_mouseOn != 3 && rayHit.rayName == null && boneKinematics.needsKinematic == true)
        {

            Debug.Log("Pausing Bone movement");
            rb2D.velocity = transform.up * thrust * Time.deltaTime;

            // Reset joint limits immediately
            JointAngleLimits2D limits = hingejoint.limits;
            limits.min = 0;
            limits.max = 0;
            hingejoint.limits = limits;

            // Reset joint motor immediately
            JointMotor2D motor = hingejoint.motor;
            motor.motorSpeed = 1f;
            motor.maxMotorTorque = 1000f;
            hingejoint.motor = motor;
           
        

                
        }
        
        
    }


    public void SetKinematic()
        {
            if (rb2D.bodyType != RigidbodyType2D.Kinematic)
            {
                Debug.Log("body is now kinematic");
                rb2D.bodyType = RigidbodyType2D.Kinematic;
                
            }
        }

    public void rotateToRestPoint(int _mouseOn)
    {
        

        if(_mouseOn == 3 && rayHit.rayName == null)
        {
            Debug.Log("Rotate to rest");
            float targetAngle = -0.566f;
                    
            // Calculate the current rotation angle in radians
            float currentAngle = plant.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            // Define the speed of rotation in degrees per second
            float rotationSpeed = 90f;

            // Calculate the target rotation quaternion
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle * Mathf.Rad2Deg);

            // Calculate the maximum angle to rotate by in one frame based on the rotation speed
            float maxAngle = rotationSpeed * Mathf.Deg2Rad * Time.deltaTime;

            // Rotate towards the target rotation by the maximum angle
            plant.transform.rotation = Quaternion.RotateTowards(plant.transform.rotation, targetRotation, maxAngle);
            // Calculate the angle difference between the current angle and the target angle
            float angleDiff = Mathf.Abs(targetAngle - plant.transform.rotation.eulerAngles.z);

            // Define a small threshold for the angle difference
            float angleThreshold = 0.01f;

            // Check if the angle difference is below the threshold
            if (angleDiff < angleThreshold)
            {
                reset = false;
                Debug.Log("Reset Disabled");
            }

        }

    }

    public void resetTrigger()
    {
        DropPointsTurnOFF();
        //plant.transform.position = startingPosition;
        Debug.Log(" reset is set to true");
    }

    public void colliderSwitchON()
    {
        if (collider != null && collider.enabled == false)
        {
            collider.enabled = true;
            boneCollider.enabled = true;
            Debug.Log("colider ON");
        }
    }

    public void colliderSwitchOFF()
    {
        if(collider != null && collider.enabled == true )
        {
            collider.enabled = false;
            boneCollider.enabled = false;
            Debug.Log("colider Off");
        }
    }

    public void DropPointsTurnOFF()
    {
        
        DropPoint1.SetActive(false);
        DropPoint2.SetActive(false);
        DropPoint3.SetActive(false);
        
    }

    public void DropPointsTurnON()
    {
        
        DropPoint1.SetActive(true);
        DropPoint2.SetActive(true);
        DropPoint3.SetActive(true);
        Invoke("colliderSwitchON", 5.0f);
        
    }
    
}
