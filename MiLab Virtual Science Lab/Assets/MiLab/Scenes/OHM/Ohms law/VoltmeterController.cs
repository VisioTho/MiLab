using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoltmeterController : MonoBehaviour
{
    public SwitchController switchControl;
    [SerializeField]
    private GameObject imageNeedle;
    // [SerializeField]
    public Slider rheostartSlider;
    [SerializeField]
    private TMP_Text voltsReader;
    private float currentSpeed = 0;
    private float targetSpeed = 0;
    private float needleSpeed = 2.0f;
    private int volts;

    void Start()
    {

    }

    void Update()
    {
        SetSpeedFromSlider();
        if (targetSpeed != currentSpeed && switchControl.switch_is_on)
        {
            UpdateSpeed();
        }
    }

    public void sliderEventController()
    {
        Vibration.Vibrate(30);
    }
    public void SetSpeedFromSlider()
    {
        if (switchControl.switch_is_on)
        {
            targetSpeed = rheostartSlider.value;
            volts = (int)Mathf.Round(targetSpeed * 20) / 20;
            voltsReader.text = volts.ToString() + " " + "V";
        }

    }

    public void UpdateSpeed()
    {
        if (targetSpeed > currentSpeed)
        {
            currentSpeed += Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, targetSpeed);
        }
        else if (targetSpeed < currentSpeed)
        {
            currentSpeed -= Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, 8.0f);
        }
        SetNeedle();

    }

    void SetNeedle()
    {
        imageNeedle.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 8.0f * 170.334f - 85.167f) * -1.0f);
    }
}
