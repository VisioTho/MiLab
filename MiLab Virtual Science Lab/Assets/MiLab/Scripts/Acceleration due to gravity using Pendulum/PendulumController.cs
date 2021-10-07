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
    private float initialClampPositiony, initialClampPositionx, initialBobPositionx, initialBobPositiony;
    [SerializeField] private TMP_Text lengthText, timerText;
    [SerializeField] private Rigidbody2D bob;
    public Slider gravityScaleSlider;
    public TMP_Dropdown gravityScaleSelector;

    [SerializeField] private TMP_Text[] tableValues;

    [SerializeField] private GameObject[] tutorialBoxes;

    [SerializeField] private GameObject[] checkmarks;


    // Start is called before the first frame update
    void Start()
    {
        lengthSlider.enabled = true;
        initialClampPositiony = clamp.transform.position.y;
        initialClampPositionx = clamp.transform.position.x;
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
        oscillateButton.interactable = false;

    }

    private bool isReset = false;

    public void ResetPendulum()
    {
        Bob.transform.position = new Vector2(initialBobPositionx, Bob.transform.position.y);
        bob.Sleep();
    }

    private Vector2 currentBobPosition;


    private void FixedUpdate()
    {

    }

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
        Debug.Log("adjust");
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

    // Update is called once per frame
    void Update()
    {
        currentBobPosition = Bob.transform.position;

    }
}

