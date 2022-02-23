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
    private float needleSpeed = 4.0f;
    private float volts;

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
        Vibration.Vibrate(60);
    }
    public void SetSpeedFromSlider()
    {
        targetSpeed = rheostartSlider.value;
        volts = (float)Mathf.Round(targetSpeed * 10f) / 10f;
        voltsReader.text = volts.ToString() + " " + "v";
    }

   // public void SetSpeed(float amt)
   // {
   //     targetSpeed = amt;
   // }

    void UpdateSpeed()
    {
        if (targetSpeed > currentSpeed)
        {
            currentSpeed += Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, targetSpeed);
        }
        else if (targetSpeed < currentSpeed)
        {
            currentSpeed -= Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, 20.0f);
        }
        SetNeedle();
    }

    void SetNeedle()
    {
        imageNeedle.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 20.0f * 166.67f - 83.335f) * -1.0f);
    }
}
