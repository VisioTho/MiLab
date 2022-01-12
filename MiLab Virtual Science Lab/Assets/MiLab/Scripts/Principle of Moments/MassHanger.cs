using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassHanger : MonoBehaviour
{
    public GameObject ruler;
    public Toggle toggle;
    private bool hungMassL = false;
    private bool hungMassR = false;
    private Vector3 initialPos;
    private GameObject massHungR, massHungL;
    private float initialMass;
    public GameObject pointOfSuspensionL, pointOfSuspensionR;
    public LineRenderer lLine, rLine;
    

    private void Start()
    {
        this.initialPos = transform.position;
        this.initialMass = gameObject.GetComponent<Rigidbody2D>().mass;
        StopBalance();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ConnPoint")
        {
            if (gameObject.GetComponent<HingeJoint2D>() == null)
            {
                massHungL = gameObject;
                hungMassL = true;
                gameObject.AddComponent<HingeJoint2D>();
               
                //gameObject.GetComponent<SpriteDragBase>().enabled = false;
                HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
                hingeJoint2D.autoConfigureConnectedAnchor = false;
                hingeJoint2D.connectedBody = ruler.GetComponent<Rigidbody2D>();
                float convertedAnchorPointx = (transform.position.x / 3.63f) * 11.09f;
                hingeJoint2D.connectedAnchor = new Vector2(convertedAnchorPointx, -3.326633f);
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            }
            
        }
        else if(collision.gameObject.name == "ConnPointR")
        {
            
            if (gameObject.GetComponent<HingeJoint2D>() == null)
            {
                massHungR = gameObject;
                hungMassR = true;
                gameObject.AddComponent<HingeJoint2D>();
                //gameObject.GetComponent<SpriteDragBase>().enabled = false;
                HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
                hingeJoint2D.autoConfigureConnectedAnchor = false;
                hingeJoint2D.connectedBody = ruler.GetComponent<Rigidbody2D>();
                float convertedAnchorPointx = (transform.position.x / 3.63f) * 11.09f;
                hingeJoint2D.connectedAnchor = new Vector2(convertedAnchorPointx, -3.326633f);
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        else 
        {
            //if(gameObject.GetComponent<HingeJoint2D>()!=null)
            //gameObject.GetComponent<HingeJoint2D>().enabled = false;
            Destroy(gameObject.AddComponent<HingeJoint2D>());

        }

        
    }
    Quaternion target;
    public void StopBalance()
    {
        if (toggle.isOn)
        {
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, Mathf.Clamp(ruler.transform.rotation.z, 0,0));
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
        }
        else
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public GameObject hangPointR, hangPointL;

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

    private void Update()
    {
       //Debug.Log("Offset is " + posOffset +" Pos on mouse down" +posOnMouseDown);
      

        if(gameObject.GetComponent<HingeJoint2D>()!=null)
        {
            if (posOffset > 1.2f)
            {
                ReleaseMass(gameObject.GetComponent<HingeJoint2D>());
            }
            
            if(hungMassL)
            {
                pointOfSuspensionL.transform.position = new Vector3(transform.position.x, pointOfSuspensionL.transform.position.y);
                lLine.enabled = true;
            }
           
                
            if(hungMassR)
            {
                pointOfSuspensionR.transform.position = new Vector3(transform.position.x, pointOfSuspensionR.transform.position.y);
                rLine.enabled = true;
            }
          
              
        }

        if (!hungMassL && !hungMassR)
        {
            Debug.Log("balance it");
            //StopBalance();
        }
           
        
    }

    float posOnMouseDown, posOffset;
    private void OnMouseDown()
    {
        hangPointR.SetActive(true);
        hangPointL.SetActive(true);
        posOffset = 0f;
        if(gameObject.GetComponent<HingeJoint2D>()!=null)
            posOnMouseDown = transform.position.y;

    }
    private void OnMouseUp()
    {
        hangPointR.SetActive(false);
        hangPointL.SetActive(false);

       
        if (gameObject.GetComponent<HingeJoint2D>() == null)
        {
            transform.position = initialPos;
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if(!hungMassR && !hungMassL)
            {
                StopBalance();
            }
        }
        else
        {
            if(!toggle.isOn)
                ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnMouseDrag()
    {
        if (gameObject.GetComponent<HingeJoint2D>()!=null)
        {
            posOffset = posOnMouseDown - transform.position.y;
            HingeJoint2D hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
            //convert transform.position into connected ancor point coordinates on the ruler
            float convertedAnchorPointx = (transform.position.x / 4.88f) * 17.02984f;
            hingeJoint2D.connectedAnchor = new Vector2(convertedAnchorPointx, -3.326633f);
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            if (convertedAnchorPointx < -20.96431f || convertedAnchorPointx > 20.96431f)
            {
                ReleaseMass(hingeJoint2D);
                //transform.position = initialPos;


            }
        }
    }

    private void ReleaseMass(HingeJoint2D hingeJoint2D)
    {
        Destroy(hingeJoint2D);
        
        
        if (hungMassL)
        {
            hangPointL.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            hangPointL.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hungMassL = false;
            lLine.enabled = false;
        }
        if (hungMassR)
        {
            hangPointR.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            hangPointR.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hungMassR = false;
            rLine.enabled = false;
        }

        if (!hungMassR && !hungMassL)
        {
            ruler.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, Mathf.Clamp(ruler.transform.rotation.z, 0, 0));
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
            Debug.Log("reset the ruler now");
        }
        
    }

   
}
