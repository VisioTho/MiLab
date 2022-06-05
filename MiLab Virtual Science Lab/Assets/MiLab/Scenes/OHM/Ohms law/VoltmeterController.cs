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
    private float needleSpeed = 0.5f;
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
            volts = (int)Mathf.Round(targetSpeed * 8) / 8;
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
        imageNeedle.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 8.0f * 160f - 169.797f) * -1.0f);
    }
}
