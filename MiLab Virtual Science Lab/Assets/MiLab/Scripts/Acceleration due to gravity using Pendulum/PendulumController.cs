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
        Bob.transform.position = new Vector2(initialBobPositionx, Bob.transform.position.y);
        bobRigidBody.Sleep();
    }


    //"changing length" is moving the bob through a series of positions along y axis. 
    public void ChangeLength(float value) => Bob.transform.position = new Vector2(currentBobPosition.x,value);


    public void IncreaseLength() => lengthSlider.value -= 0.1f; //Increase length by 0.1f everytime a button is pressed


    public void DecreaseLength() => lengthSlider.value += 0.1f; //decrease length by 0.1f everytime a button is pressed


    public void AdjustGravity(float val)
    {
        bobRigidBody.gravityScale = val;

        if (val != 5 && val != 10 && val != 0)
            gravityScaleSelector.value = 3;
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


    public void AdjustMass(float val)
    {
        bobRigidBody.mass = val;
        Bob.transform.localScale = new Vector2(val, val);
    }


    // Update is called once per frame
    void Update()
    {
        currentBobPosition = Bob.transform.position;
        Debug.Log(Bob.transform.localScale);
    }
}

