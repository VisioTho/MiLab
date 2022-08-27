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
    public GameObject massHungR;
    public GameObject massHungL;
    private float initialMass;
    public GameObject pointOfSuspensionL, pointOfSuspensionR;
    public LineRenderer lLine, rLine;
    public float massRotationValue; //adds rotation to the ruler based on which mass is attached. Assigned in the inspector
    int hungMassCount;
    private float leftMassRotation, rightMassRotation;
    private float anchorPointX;

    public float leftMassRotationValue, rightMassRotationValue;

    private bool mouseDown, mouseUp;


    private void Start()
    {
        this.initialPos = transform.position;
        
        this.initialMass = gameObject.GetComponent<Rigidbody2D>().mass;
        
        massHungR = null;
        massHungL = null;
        
    }
        

    private void OnTriggerEnter2D(Collider2D col)
    {
        HandleMassAttachment(col);

    }

    private void HandleMassAttachment(Collider2D collision)
    {   
        if (collision.gameObject.name == "ConnPointR1")
        {
            AttachRightMass(2.16f);
            RotateRuler(-0.5f - massRotationValue);
            SetRightMassRotationValue(0.5f);
            SetConnectionPoints("right");
        }

        else if (collision.gameObject.name == "ConnPointR2")
        {
            //ruler.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 3f);
            AttachRightMass(4.26f);
            RotateRuler(-1.0f - massRotationValue);
            SetRightMassRotationValue(1.0f);
            SetConnectionPoints("right");
        }
        
        else if (collision.gameObject.name == "ConnPointR3")
        {
            AttachRightMass(6.45f);
            RotateRuler(-1.5f - massRotationValue);
            SetRightMassRotationValue(1.5f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR4")
        {
            AttachRightMass(8.58f);
            RotateRuler(-2.0f - massRotationValue);
            SetRightMassRotationValue(2.0f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR5")
        {
            AttachRightMass(10.7f);
            RotateRuler(-2.5f - massRotationValue);
            SetRightMassRotationValue(2.5f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR6")
        {
            AttachRightMass(12.80f);
            RotateRuler(-3.0f - massRotationValue);
            SetRightMassRotationValue(3.0f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR7")
        {
            AttachRightMass(15.02f);
            RotateRuler(-3.5f - massRotationValue);
            SetRightMassRotationValue(3.5f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR8")
        {
            AttachRightMass(17.08f);
            RotateRuler(-4.0f - massRotationValue);
            SetRightMassRotationValue(4.0f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR9")
        {
            AttachRightMass(19.33f);
            RotateRuler(-4.5f - massRotationValue);
            SetRightMassRotationValue(4.5f);
            SetConnectionPoints("right");
        }
        else if (collision.gameObject.name == "ConnPointR10")
        {
            AttachRightMass(21.46f);
            RotateRuler(-5.0f - massRotationValue);
            SetRightMassRotationValue(5.0f);
            SetConnectionPoints("right");
        }

        else if (collision.gameObject.name == "ConnPoint9")
        {
            AttachLeftMass(-2.16f);
            RotateRuler(0.5f + massRotationValue);
            SetLeftMassRotation(0.5f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint8")
        {
            AttachLeftMass(-4.29f);
            RotateRuler(1.0f + massRotationValue);
            SetLeftMassRotation(1.0f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint7")
        {
            AttachLeftMass(-6.46f);
            RotateRuler(1.5f + massRotationValue);
            SetLeftMassRotation(1.5f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint6")
        {
            AttachLeftMass(-8.58f);
            RotateRuler(2.0f + massRotationValue);
            SetLeftMassRotation(2.0f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint5")
        {
            AttachLeftMass(-10.75f);
            RotateRuler(2.5f + massRotationValue);
            SetLeftMassRotation(2.5f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint4")
        {
            AttachLeftMass(-12.87f);
            RotateRuler(3.0f + massRotationValue);
            SetLeftMassRotation(3.0f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint3")
        {
            AttachLeftMass(-15.05f);
            RotateRuler(3.5f + massRotationValue);
            SetLeftMassRotation(3.5f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint2")
        {
            AttachLeftMass(-17.08f);
            RotateRuler(4.0f + massRotationValue);
            SetLeftMassRotation(4.0f);
            SetConnectionPoints("left");
        }
        else if (collision.gameObject.name == "ConnPoint1")
        {
            AttachLeftMass(-19.3f);
            RotateRuler(4.5f + massRotationValue);
            SetLeftMassRotation(4.5f);
            SetConnectionPoints("left");
        }
       
        else
        {
            Destroy(gameObject.GetComponent<HingeJoint2D>());
        }

        void SetRightMassRotationValue(float n)
        {
            MassManager.rotationByRightMass = massRotationValue + n;
        }

        void SetLeftMassRotation(float n)
        {
            MassManager.rotationByLeftMass = massRotationValue + n;
        }

        //location of masses on the ruler. e.g. at 40cm mark
        void SetConnectionPoints(string side)
        {
            if (side == "right")
                MassManager.hangPointR = collision.gameObject.name;

            else if (side == "left")
                MassManager.hangPointL = collision.gameObject.name;

        }
    }


    private void AttachLeftMass(float f)
    {
        MassManager.massHungOnLeft = gameObject;
        massHungL = gameObject;
        
        MassManager.lMassIsReleased = false;
        
        if (gameObject.GetComponent<HingeJoint2D>() == null)
        {
            gameObject.AddComponent<HingeJoint2D>();
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            hingeJoint2D.autoConfigureConnectedAnchor = false;
            hingeJoint2D.connectedBody = ruler.GetComponent<Rigidbody2D>();
            hingeJoint2D.connectedAnchor = new Vector2(f, -2.7f);
            this.anchorPointX = f;
            
            if (leftMassRotation == 0)
                leftMassRotation = ruler.transform.rotation.z;
        }

        MassManager.ToggleHangPoints(MassManager.lConnectionPoints, false);
        
    }

    private void AttachRightMass(float f)
    {
        MassManager.massHungOnRight = gameObject;
        massHungR = gameObject;
       
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
        MassManager.ToggleHangPoints(MassManager.rConnectionPoints, false);

    }

    private void RotateRuler(float d)
    {
        ruler.transform.LeanRotateZ(ruler.transform.eulerAngles.z + d, .5f);
    }
   
    public GameObject[] hangPointR, hangPointL;

    
    private void Update()
    {
        Debug.Log("Right side is" + MassManager.hangPointR + " and left side is:" + MassManager.hangPointL + "gameobjects: left " + MassManager.massHungOnLeft + " right " + MassManager.massHungOnRight);
        Debug.Log("rotation by left mass: " + MassManager.rotationByLeftMass + " rotation by right mass: " + MassManager.rotationByRightMass);
        if(MassManager.massHungOnLeft!=null && MassManager.massHungOnRight)
            BalanceRuler();

        MoveMassOutOfBounds();

    }

    private void BalanceRuler()
    {
        if ((MassManager.hangPointL == "ConnPoint2" && MassManager.massHungOnLeft.name == "Mass50g") || (MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass100g"))
        {

            if ((MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR8" && MassManager.massHungOnRight.name == "Mass50g" && MassManager.canBalance))
            {
                Debug.Log("zikuyenera kutheka" + "mass rotation value" + MassManager.massHungOnLeft.GetComponent<MassHanger>().massRotationValue);
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint4" && MassManager.massHungOnLeft.name == "Mass50g") || (MassManager.hangPointL == "ConnPoint7" && MassManager.massHungOnLeft.name == "Mass100g"))
        {
            if ((MassManager.hangPointR == "ConnPointR3" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR6" && MassManager.massHungOnRight.name == "Mass50g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass50g") || (MassManager.hangPointL == "ConnPoint8" && MassManager.massHungOnLeft.name == "Mass100g"))
        {
            if ((MassManager.hangPointR == "ConnPointR2" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass50g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint8" && MassManager.massHungOnLeft.name == "Mass50g") || (MassManager.hangPointL == "ConnPoint9" && MassManager.massHungOnLeft.name == "Mass100g"))
        {
            if ((MassManager.hangPointR == "ConnPointR1" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR2" && MassManager.massHungOnRight.name == "Mass50g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint1" && MassManager.massHungOnLeft.name == "Mass50g") || (MassManager.hangPointL == "ConnPoint7" && MassManager.massHungOnLeft.name == "Mass150g"))
        {
            if ((MassManager.hangPointR == "ConnPointR3" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR9" && MassManager.massHungOnRight.name == "Mass50g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        //100g vs 100g
        else if ((MassManager.hangPointL == "ConnPoint1" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint4" && MassManager.massHungOnLeft.name == "Mass150g"))
        {
            if ((MassManager.hangPointR == "ConnPointR6" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR9" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint4" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass150g"))
        {
            if ((MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR6" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }
        
        else if ((MassManager.hangPointL == "ConnPoint7" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint8" && MassManager.massHungOnLeft.name == "Mass150g"))
        {
            if ((MassManager.hangPointR == "ConnPointR2" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR3" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        //100g vs 200g

        if ((MassManager.hangPointL == "ConnPoint2" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass200g"))
        {

            if ((MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR8" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Debug.Log("zikuyenera kutheka" + "mass rotation value" + MassManager.massHungOnLeft.GetComponent<MassHanger>().massRotationValue);
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint4" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint7" && MassManager.massHungOnLeft.name == "Mass200g"))
        {
            if ((MassManager.hangPointR == "ConnPointR3" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR6" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint8" && MassManager.massHungOnLeft.name == "Mass200g"))
        {
            if ((MassManager.hangPointR == "ConnPointR2" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint8" && MassManager.massHungOnLeft.name == "Mass100g") || (MassManager.hangPointL == "ConnPoint9" && MassManager.massHungOnLeft.name == "Mass200g"))
        {
            if ((MassManager.hangPointR == "ConnPointR1" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR2" && MassManager.massHungOnRight.name == "Mass100g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        
        // 150g vs 200g
        if ((MassManager.hangPointL == "ConnPoint2" && MassManager.massHungOnLeft.name == "Mass150g") || (MassManager.hangPointL == "ConnPoint4" && MassManager.massHungOnLeft.name == "Mass200g"))
        {

            if ((MassManager.hangPointR == "ConnPointR6" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR8" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }

        else if ((MassManager.hangPointL == "ConnPoint6" && MassManager.massHungOnLeft.name == "Mass150g") || (MassManager.hangPointL == "ConnPoint7" && MassManager.massHungOnLeft.name == "Mass200g"))
        {

            if ((MassManager.hangPointR == "ConnPointR3" && MassManager.massHungOnRight.name == "Mass200g" && MassManager.canBalance) || (MassManager.hangPointR == "ConnPointR4" && MassManager.massHungOnRight.name == "Mass150g" && MassManager.canBalance))
            {
                Balance();
                MassManager.canBalance = false;
            }
        }


        void Balance()
        {
            ruler.transform.LeanRotateZ(0.0f, .5f);
        }
    }

    private void MoveMassOutOfBounds()
    {
        if (gameObject.GetComponent<HingeJoint2D>() != null)
        {
            if (posOffsetY > 0.01f)
            {
                DetachMass();
            }

            if (posOffsetX < 1.0f && posOffsetX > -1.0f)
            {
                //RegisterMassDetachment();
            }

        }
    }

    private void DetachMass()
    {
        ReleaseMass(gameObject.GetComponent<HingeJoint2D>());

        MassManager.canBalance = true;

        RegisterMassDetachment();

        //remove mass from ruler and return ruler rotation to default
        void ReleaseMass(HingeJoint2D hingeJoint2D)
        {
            Destroy(hingeJoint2D);

            if (MassManager.lMassIsReleased && MassManager.RMassIsReleased)
            {
                ruler.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            }
        }

        //change mass detachment variables based on where the detached mass was 
        void RegisterMassDetachment()
        {
            if (gameObject == MassManager.massHungOnLeft)
            {
                MassManager.lMassIsReleased = true;
                HandleMassDetachment();
                MassManager.massHungOnLeft = null;
                MassManager.ToggleHangPoints(MassManager.lConnectionPoints, true);

            }
            else if (gameObject == MassManager.massHungOnRight)
            {
                MassManager.RMassIsReleased = true;
                HandleMassDetachment();
                MassManager.massHungOnRight = null;
                MassManager.ToggleHangPoints(MassManager.rConnectionPoints, true);
            }
        }
    }


    private void HandleMassDetachment()
    {
        RotateRulerAfterMassDetachment();

        //subtract current rotation value of the detached mass from the current rotation of the ruler
        void RotateRulerAfterMassDetachment()
        {
            if (!(MassManager.lMassIsReleased && MassManager.RMassIsReleased))
            {
                if (MassManager.lMassIsReleased)
                {
                    //ruler.transform.Rotate(0.0f, 0.0f, transform.rotation.z - MassManager.rotationByLeftMass, Space.Self);
                    ruler.transform.LeanRotateZ(-MassManager.rotationByRightMass, .5f);
                    MassManager.hangPointL = "";
                    
                }

                if (MassManager.RMassIsReleased)
                {
                    //ruler.transform.Rotate(0.0f, 0.0f, transform.rotation.z + MassManager.rotationByRightMass, Space.Self);
                    ruler.transform.LeanRotateZ(MassManager.rotationByLeftMass, .5f);
                    MassManager.hangPointR = "";
                }

            }
            else if (MassManager.lMassIsReleased && MassManager.RMassIsReleased)
            {
                Vector3 target = new Vector3(0, 0, 0.0f);
                MassManager.rotationByLeftMass = 0f;
                MassManager.rotationByRightMass = 0f;
                ruler.transform.LeanRotate(target, .5f);
            }
        }
    }


    float posOffsetY, posOffsetX;
    Vector2 posOnMouseDown;
    private void OnMouseDown()
    {
        mouseDown = true;
        MassManager.mouseUp = false; 
        foreach (GameObject a in hangPointL)
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
        mouseDown = false;
        MassManager.mouseUp = true;
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
            
            if (convertedAnchorPointx < -22.0f || convertedAnchorPointx > 22.0f)
            {
                DetachMass();
            }
        }
        else if(gameObject.GetComponent<HingeJoint2D>() == null)
        {
            //Destroy(gameObject.GetComponent<HingeJoint2D>());
        }
        
    }

   

   
}
