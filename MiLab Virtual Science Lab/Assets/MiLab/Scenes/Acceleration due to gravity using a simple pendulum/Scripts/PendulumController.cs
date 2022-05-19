using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PendulumController : MonoBehaviour
{
    public Slider lengthSlider;
    public Button oscillateButton;

    public GameObject Bob;

    float initialBobPositionx, initialBobPositiony;
    public TMP_Text lengthText, timerText;

    public Rigidbody2D bobRigidBody;

    public Slider gravityScaleSlider, massAdjustSlider;
    public TMP_Dropdown gravityScaleSelector;

    public TMP_Text massLabel;

    private Vector2 currentBobPosition;
    private void Awake()
    {
        //lengthSlider.maxValue = Bob.transform.position.y;
    }
    void Start()
    {
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
    }


    public void ResetPendulum()
    {
        // Bob.transform.position = new Vector2(initialBobPositionx, Bob.transform.position.y);
        transform.LeanMoveLocalX(initialBobPositionx, 0.4f);
        transform.LeanMoveLocalY(transform.position.y + 0.3f, 0.4f);
        transform.GetComponent<DistanceJoint2D>().distance = lengthSlider.value;
        bobRigidBody.Sleep();
    }

    public void StopPendulum()
    {
        transform.LeanMoveLocalX(-0.36f, 0.4f);
    }

    //"changing length" is moving the bob through a series of positions along y axis. 
    public void ChangeLength(float value) => transform.GetComponent<DistanceJoint2D>().distance = value; 


    public void IncreaseLength() => lengthSlider.value -= 0.1f; //Increase length by 0.1f everytime a button is pressed


    public void DecreaseLength() => lengthSlider.value += 0.1f; //decrease length by 0.1f everytime a button is pressed


    public void AdjustGravity(float val)
    {
        //bobRigidBody.gravityScale = val;
        var gravity = 0f;
        if (val==5)
        {
            gravity = 5;
            bobRigidBody.gravityScale = gravity;
            gravityScaleSelector.value = 0;
        }
        else if (val == 0)
        {
            gravity = 0;
            bobRigidBody.gravityScale = gravity;
            gravityScaleSelector.value = 1;
        }
        else if (val == 10)
        {
            gravity = 10;
            bobRigidBody.gravityScale = gravity;
            gravityScaleSelector.value = 2;
        }
        else
        {
            gravity = val;
            bobRigidBody.gravityScale = gravity;
            gravityScaleSelector.value = 3;
        }

        //if (val != 5 && val != 10 && val != 0)
        //gravityScaleSelector.value = 3;
    }


    public void SelectGravityScale(int val)
    {
        var gravity = 0f;

        if (val == 0)
        {
            gravity = 5;
            bobRigidBody.gravityScale = gravity;
        }
        else if (val == 1)
        {
            gravity = 0;
            bobRigidBody.gravityScale = gravity;
        }
        else if (val == 2)
        {
            gravity = 10;
            bobRigidBody.gravityScale = gravity;
        }
        else if (val == 3)
        {
            gravity = gravityScaleSlider.value;
        }

        gravityScaleSlider.value = gravity;
    }


    public TMP_Text bobMass;
    public void AdjustMass(float val)
    {
        if(val==1)
        {
            ChangeMass(0.07f, "30");
        }
        if(val==2)
        {
            ChangeMass(0.074f, "35");
        }
        if(val==3)
        {
            ChangeMass(0.078f, "40");
        }

        void ChangeMass(float val, string weight)
        {
            Bob.transform.localScale = new Vector2(val, val);
            bobMass.text = weight + " g";
        }
    }


    // Update is called once per frame
    void Update()
    {
        currentBobPosition = Bob.transform.position;
        //Debug.Log("Scale is " +Bob.transform.localScale);
    }
}

