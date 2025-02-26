using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeakerTiltCintroller : MonoBehaviour
{
    [SerializeField]
    private GameObject imageNeedle;
    // [SerializeField]
    public Slider rheostartSlider;
    private float currentSpeed = 0;
    private float targetSpeed = 0;
    private float needleSpeed = 100f;
  //  private float volts;

    void Start()
    {

    }

    void Update()
    {
        SetSpeedFromSlider();
        if (targetSpeed != currentSpeed)
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
      //  volts = (float)Mathf.Round(targetSpeed * 10f) / 10f;
     //   voltsReader.text = volts.ToString() + " " + "v";
    }

     public void SetSpeed()
     {
         targetSpeed = 40;
     }

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
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, 40.487f);
        }
        SetNeedle();
    }

    void SetNeedle()
    {
        imageNeedle.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 40.487f * 40.487f - 40.487f) * -1.0f);
    }
}
