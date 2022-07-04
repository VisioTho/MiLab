using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassHanger : MonoBehaviour
{
    public GameObject ruler;
    public Toggle toggle;
    private bool hungMassL;
    private bool lMassIsReleased;
    private bool RMassIsReleased;
    private bool hungMassR;
    private Vector3 initialPos;
    private GameObject massHungR, massHungL;
    private float initialMass;
    public GameObject pointOfSuspensionL, pointOfSuspensionR;
    public LineRenderer lLine, rLine;
    public float massRotationValue; //adds rotation to the ruler based on which mass is attached. Assigned in the inspector
    int hungMassCount;
    private float leftMassRotation, rightMassRotation;
    private float anchorPointX;
    

    private void Start()
    {
        this.initialPos = transform.position;
        
        this.initialMass = gameObject.GetComponent<Rigidbody2D>().mass;
        StopBalance();
        massHungR = null;
        massHungL = null;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Touched something...");
        HandleMassAttachment(col);
    }

    private void HandleMassAttachment(Collider2D collision)
    {

        if (collision.gameObject.name == "ConnPointR2")
        {
            //ruler.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 3f);
            AttachRightMass(4.26f);
            RotateRuler(-1.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR1")
        {
            AttachRightMass(2.16f);
            RotateRuler(-1.0f - massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPointR3")
        {
            AttachRightMass(6.45f);
            RotateRuler(-1.0f - massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPointR4")
        {
            AttachRightMass(8.58f);
            RotateRuler(-2.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR5")
        {
            AttachRightMass(10.7f);
            RotateRuler(-2.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR6")
        {
            AttachRightMass(12.80f);
            RotateRuler(-3.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR7")
        {
            AttachRightMass(15.02f);
            RotateRuler(-3.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR8")
        {
            AttachRightMass(17.08f);
            RotateRuler(-4.0f - massRotationValue);
           
        }
        else if (collision.gameObject.name == "ConnPointR9")
        {
            AttachRightMass(19.33f);
            RotateRuler(-4.0f - massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPointR10")
        {
            AttachRightMass(21.46f);
            RotateRuler(-4.0f - massRotationValue);
            
        }

        else if (collision.gameObject.name == "ConnPoint9")
        {
            AttachLeftMass(-2.16f);
            RotateRuler(1.0f + massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPoint8")
        {
            AttachLeftMass(-4.29f);
            RotateRuler(1.0f + massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPoint7")
        {
            AttachLeftMass(-6.46f);
            RotateRuler(1.0f + massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPoint6")
        {
            AttachLeftMass(-8.58f);
            RotateRuler(2.0f + massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPoint5")
        {
            AttachLeftMass(-10.75f);
            RotateRuler(1.0f + massRotationValue);
            

        }
        else if (collision.gameObject.name == "ConnPoint4")
        {
            AttachLeftMass(-12.87f);
            RotateRuler(3.0f + massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPoint3")
        {
            AttachLeftMass(-15.05f);
            RotateRuler(3.0f + massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPoint2")
        {
            AttachLeftMass(-17.08f);
            RotateRuler(4.0f + massRotationValue);
            
        }
        else if (collision.gameObject.name == "ConnPoint1")
        {
            AttachLeftMass(-19.3f);
            RotateRuler(4.0f + massRotationValue);
            
        }
       
        else
        {
            //if(gameObject.GetComponent<HingeJoint2D>()!=null)
            //gameObject.GetComponent<HingeJoint2D>().enabled = false;
            Destroy(gameObject.GetComponent<HingeJoint2D>());
        } 
        
       
    }

    private void RotateRuler(float d)
    {
        //Rotate the cube by converting the angles into a quaternion.
        //Quaternion target = Quaternion.Euler(0, 0, transform.rotation.z + d);

        // Dampen towards the target rotation
        //ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
        //Debug.Log("Should rotate..");
        ruler.transform.Rotate(0.0f, 0.0f, transform.rotation.z + d, Space.Self);
        //target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, d);
        //ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
    }

    private void AttachLeftMass(float f)
    {
        MassManager.massHungOnLeft = gameObject;
        MassManager.lMassIsReleased = false;
        
        if (gameObject.GetComponent<HingeJoint2D>() == null)
        {
            gameObject.AddComponent<HingeJoint2D>();
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            hingeJoint2D.autoConfigureConnectedAnchor = false;
            hingeJoint2D.connectedBody = ruler.GetComponent<Rigidbody2D>();
            hingeJoint2D.connectedAnchor = new Vector2(f, -2.7f);
            this.anchorPointX = f;
            if(leftMassRotation == 0)
                leftMassRotation = ruler.transform.rotation.z;
        }
        
    }

    private void AttachRightMass(float f)
    {
        MassManager.massHungOnRight = gameObject;
        MassManager.RMassIsReleased = false;
        
        if (gameObject.GetComponent<HingeJoint2D>() == null)
        {   
            gameObject.AddComponent<HingeJoint2D>();
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            hingeJoint2D.autoConfigureConnectedAnchor = false;
            hingeJoint2D.connectedBody = ruler.GetComponent<Rigidbody2D>();
            hingeJoint2D.connectedAnchor = new Vector2(f, -2.7f);
            this.anchorPointX = f;
            if(rightMassRotation == 0)
                rightMassRotation = ruler.transform.rotation.z;
        }
       
    }

    Quaternion target;
    public void StopBalance()
    {
        /*if (toggle.isOn)
        {
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, Mathf.Clamp(ruler.transform.rotation.z, 0,0));
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
        }
        else
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;*/
    }
    public GameObject[] hangPointR, hangPointL;

    public void MoveLeftMass(int side)
    {
        if (hungMassL)
        {
            if (side == 1)
            {
                HingeJoint2D hinjeJoint = gameObject.GetComponent<HingeJoint2D>();
                hinjeJoint.connectedAnchor = new Vector2(hinjeJoint.connectedAnchor.x - 0.1f, hinjeJoint.connectedAnchor.y);
            }
            else
            {
                HingeJoint2D hinjeJoint = gameObject.GetComponent<HingeJoint2D>();
                hinjeJoint.connectedAnchor = new Vector2(hinjeJoint.connectedAnchor.x + 0.1f, hinjeJoint.connectedAnchor.y);
            }
        }
    }

    public void MoveRightMass(int side)
    {
        if (hungMassR)
        {
            if (side == 1)
            {
                HingeJoint2D hinjeJoint = gameObject.GetComponent<HingeJoint2D>();
                hinjeJoint.connectedAnchor = new Vector2(hinjeJoint.connectedAnchor.x - 0.1f, hinjeJoint.connectedAnchor.y);
            }
            else
            {
                HingeJoint2D hinjeJoint = gameObject.GetComponent<HingeJoint2D>();
                hinjeJoint.connectedAnchor = new Vector2(hinjeJoint.connectedAnchor.x + 0.1f, hinjeJoint.connectedAnchor.y);
            }           

        }
    }
    Quaternion rulerRotation;
    bool hasBothMassesAttached = false;
    private void Update()
    {

        
        // Debug.Log("Ruler rotation is: " + ruler.transform.rotation);
        //Debug.Log("Right Mass" + MassManager.massHungOnRight + " Left Mass " + MassManager.massHungOnLeft);
        //Debug.Log("both attached? " + MassManager.hasHadBothMassesAttached);
        Debug.Log("ROtation for left: " + MassManager.rotationByLeftMass + " Rotation for right " + MassManager.rotationByRightMass);

        if(MassManager.massHungOnLeft!=null && MassManager.massHungOnRight==null && !MassManager.hasHadBothMassesAttached)
        {
            
            MassManager.rotationByLeftMass = ruler.transform.eulerAngles.z;
        }
        else if(MassManager.massHungOnLeft == null && MassManager.massHungOnRight != null && !MassManager.hasHadBothMassesAttached)
        {
           
            MassManager.rotationByRightMass = ruler.transform.eulerAngles.z;
        }
        else if(MassManager.massHungOnLeft != null && MassManager.massHungOnRight == null && MassManager.hasHadBothMassesAttached)
        {
            
            MassManager.rotationByLeftMass = ruler.transform.eulerAngles.z - MassManager.rotationByLeftMass;
        }
        else if(MassManager.massHungOnLeft == null && MassManager.massHungOnRight != null && MassManager.hasHadBothMassesAttached)
        {
            
            MassManager.rotationByRightMass = ruler.transform.eulerAngles.z - MassManager.rotationByLeftMass;
        }


        if(MassManager.massHungOnLeft == null && MassManager.massHungOnRight == null)
        {
            MassManager.hasHadBothMassesAttached = false;
        }
        else if(MassManager.massHungOnLeft != null && MassManager.massHungOnRight != null)
        {
            MassManager.hasHadBothMassesAttached = true;
            MassManager.rotationByLeftMass = 0f;
            MassManager.rotationByRightMass = 0f;
        }

        //Debug.Log("Connected anchor " + anchorPointX);
        if (gameObject.GetComponent<HingeJoint2D>()!=null)
        {
            if (posOffsetY > 0.5f)
            {
                RegisterMassDetachment();
            }
            
            

        }
        
    }

    private void RegisterMassDetachment()
    {
        ReleaseMass(gameObject.GetComponent<HingeJoint2D>());

        if (gameObject == MassManager.massHungOnLeft)
        {
            //Debug.Log("released mass is on left side");
            MassManager.lMassIsReleased = true;
            HandleMassDetachment();
            MassManager.massHungOnLeft = null;
            //ruler.transform.Rotate(0.0f, 0.0f, leftMassRotation, Space.Self);
        }
        else if (gameObject == MassManager.massHungOnRight)
        {
            //Debug.Log("released mass is on right side");
            MassManager.RMassIsReleased = true;
            HandleMassDetachment();
            MassManager.massHungOnRight = null;
            //ruler.transform.Rotate(0.0f, 0.0f, rightMassRotation, Space.Self);
        }
    }

    
    private void HandleMassDetachment()
    {
        
        if(anchorPointX == 4.26f)
        {
            Debug.Log("We know your anchor point");
            //RotateRuler(-1.0f + massRotationValue);

        }
        else if(anchorPointX == -4.29f)
        {
            Debug.Log("We Still know your anchor point");
        }

        if(!(MassManager.lMassIsReleased && MassManager.RMassIsReleased))
        {
            
            //Debug.Log("Handling..");
            /*if (gameObject.name == "Mass100g")
            {
                if (gameObject.transform.position.x < 0)
                {
                     RotateRuler(-0.5f);
                }
                else
                     RotateRuler(0.5f);
            }

            if (gameObject.name == "Mass200g")
            {
                if (gameObject.transform.position.x < 0)
                {
                     RotateRuler(-1f);
                }
                else
                     RotateRuler(1f);
            }

            if (gameObject.name == "Mass300g")
            {
                 if (gameObject.transform.position.x < 0)
                 {
                     RotateRuler(-1.5f);
                 }
                 else
                     RotateRuler(1.5f);
            }

            if (gameObject.name == "Mass400g")
            {
                if (gameObject.transform.position.x < 0)
                {
                     RotateRuler(-2f);
                }
                else
                     RotateRuler(2f);
            }*/
        } 
        else if(MassManager.lMassIsReleased && MassManager.RMassIsReleased)
        {
            
            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, 0, 0.0f);
            MassManager.rotationByLeftMass = 0f;
            MassManager.rotationByRightMass = 0f;

            // Dampen towards the target rotation
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
           //Debug.Log("Should rotate..");
        }
    }

    float posOffsetY, posOffsetX;
    Vector2 posOnMouseDown;
    private void OnMouseDown()
    {
        foreach(GameObject a in hangPointL)
        {
            a.SetActive(true);
        }

        foreach (GameObject a in hangPointR)
        {
            a.SetActive(true);
        }
        
        
        posOffsetY = 0f;
        posOffsetX = 0f;
        if(gameObject.GetComponent<HingeJoint2D>()!=null)
        {
            posOnMouseDown.y = transform.position.y;
            posOnMouseDown.x = transform.position.x;
        }
            

    }
    private void OnMouseUp()
    {
        if (gameObject.GetComponent<HingeJoint2D>() == null)
        {
            transform.position = initialPos;
        }
        else
        {

        }
    }

    
    private void OnMouseDrag()
    {
        if (gameObject.GetComponent<HingeJoint2D>()!=null)
        {
           
            float convertedAnchorPointx = (transform.position.x / 4.88f) * 17.02984f;
            posOffsetY = posOnMouseDown.y - transform.position.y;
            posOffsetX = posOnMouseDown.x - transform.position.x; 
            //Debug.Log("Offset y: " + posOffsetY);
   
            //RegisterMassDetachment();
            /*
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            Debug.Log("position: " + transform.position.x);
            //convert transform.position into connected ancor point coordinates on the ruler
            
            if(transform.position == hangPointL[0].transform.position)
            {
                hingeJoint2D.connectedAnchor = new Vector2(-19.3f, -2.7f);
            }
            //hingeJoint2D.connectedAnchor = new Vector2(convertedAnchorPointx, -3.326633f);
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;*/

            if (convertedAnchorPointx < -22.0f || convertedAnchorPointx > 22.0f)
            {
                RegisterMassDetachment();
            }
        }
        else if(gameObject.GetComponent<HingeJoint2D>() == null)
        {
            //Destroy(gameObject.GetComponent<HingeJoint2D>());
        }
        
    }

    private void ReleaseMass(HingeJoint2D hingeJoint2D)
    {
        Destroy(hingeJoint2D);

        if (MassManager.lMassIsReleased && MassManager.RMassIsReleased)
        {
            ruler.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        }
    }

   
}
