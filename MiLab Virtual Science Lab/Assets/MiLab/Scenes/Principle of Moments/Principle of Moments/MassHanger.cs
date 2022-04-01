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
    public float massRotationValue; //adds rotation to the ruler based on which mass is attached.
    int hungMassCount;
    

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
        Debug.Log("Touched something...");
        HandleMassAttachment(col);
    }

    private void HandleMassAttachment(Collider2D collision)
    {

        if (collision.gameObject.name == "ConnPointR2")
        {
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
    private void Update()
    {
        
        Debug.Log("Ruler rotation is: " + ruler.transform.rotation);

        if (gameObject.GetComponent<HingeJoint2D>()!=null)
        {
            if (posOffset > 1.2f)
            {
                ReleaseMass(gameObject.GetComponent<HingeJoint2D>());

                if (gameObject == MassManager.massHungOnLeft)
                {
                    Debug.Log("released mass is on left side");
                    MassManager.lMassIsReleased = true;
                    HandleMassDetachment();
                    MassManager.massHungOnLeft = null;
                }
                else if (gameObject == MassManager.massHungOnRight)
                {
                    Debug.Log("released mass is on right side");
                    MassManager.RMassIsReleased = true;
                    HandleMassDetachment();
                    MassManager.massHungOnRight = null;
                }

            }
              
        }
        
    }

    private void HandleMassDetachment()
    {
        if(!(MassManager.lMassIsReleased && MassManager.RMassIsReleased))
        {
            Debug.Log("Handling..");
            if (gameObject.name == "Mass100g")
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
            }
        } 
        else if(MassManager.lMassIsReleased && MassManager.RMassIsReleased)
        {
            
            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, 0, 0.0f);

            // Dampen towards the target rotation
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
            Debug.Log("Should rotate..");
        }
    }

    float posOnMouseDown, posOffset;
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
        
        
        posOffset = 0f;
        if(gameObject.GetComponent<HingeJoint2D>()!=null)
            posOnMouseDown = transform.position.y;

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
            posOffset = posOnMouseDown - transform.position.y;
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            Debug.Log("position: " + transform.position.x);
            //convert transform.position into connected ancor point coordinates on the ruler
            float convertedAnchorPointx = (transform.position.x / 4.88f) * 17.02984f;
            //hingeJoint2D.connectedAnchor = new Vector2(convertedAnchorPointx, -3.326633f);
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            if (convertedAnchorPointx < -22.0f || convertedAnchorPointx > 22.0f)
            {
                ReleaseMass(hingeJoint2D);
            }
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
