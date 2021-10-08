using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PendulumController : MonoBehaviour
{
    [SerializeField] private Slider lengthSlider;
    [SerializeField] private Button oscillateButton, stopOscillationButton;
    [SerializeField] private GameObject clamp, Bob;
    private float initialBobPositionx, initialBobPositiony;
    [SerializeField] private TMP_Text lengthText, timerText;
    [SerializeField] private Rigidbody2D bob;
    public Slider gravityScaleSlider, massAdjustSlider;
    public TMP_Dropdown gravityScaleSelector;
    public TMP_Text massLabel;

    // Start is called before the first frame update
    void Start()
    {
        lengthSlider.enabled = true;
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
        oscillateButton.interactable = false;
        massAdjustSlider.maxValue = Bob.transform.localScale.x;
        massAdjustSlider.minValue = Bob.transform.localScale.x-0.5f;
        Debug.Log(Bob.transform.localScale.x);
    }

    private bool isReset = false;

    public void ResetPendulum()
    {
        Bob.transform.position = new Vector2(initialBobPositionx, Bob.transform.position.y);
        bob.Sleep();
    }

    private Vector2 currentBobPosition;

    public void ChangeLength(float value)
    {
        Debug.Log("adjusted");
        Bob.transform.position = new Vector2(currentBobPosition.x, value);
    }
    public void IncreaseLength()
    {
        lengthSlider.value -= 0.1f;
    }
    public void DecreaseLength()
    {
        lengthSlider.value += 0.1f;
    }
    public void AdjustGravity(float val)
    {
        bob.gravityScale = val;
        if (val != 5 && val != 10 && val != 0)
            gravityScaleSelector.value = 3;
    }
    public void SelectGravityScale(int val)
    {
        float gravity = 0;
        if (val == 0)
        {
            gravity = 5;
            bob.gravityScale = gravity;
        }
        if (val == 1)
        {
            gravity = 0;
            bob.gravityScale = gravity;
        }
        if (val == 2)
        {
            gravity = 10;
            bob.gravityScale = gravity;
        }
        if (val == 3)
        {
            gravity = gravityScaleSlider.value;
        }
        gravityScaleSlider.value = gravity;
    }

    public void AdjustMass(float val)
    {
        bob.mass = val;
        Bob.transform.localScale = new Vector2(val, val);
    }

    // Update is called once per frame
    void Update()
    {
        currentBobPosition = Bob.transform.position;

    }
}

