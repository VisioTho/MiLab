using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmeterController : MonoBehaviour
{
    public SwitchController switchController;
    [SerializeField]
    private GameObject imageNeedle;
    // [SerializeField]
    public Slider rheostartSlider;
    [SerializeField]
    private TMP_Text amperesReader;
    private float currentSpeed;
    private float targetSpeed;
    private float needleSpeed;
    private float amperes;
    // Start is called before the first frame update
    void Start()
    {
        targetSpeed = 0;
        currentSpeed = 0;
        needleSpeed = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedFromSlider();
        if (targetSpeed != currentSpeed && switchController.switch_is_on)
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
        if (switchController.switch_is_on)
        {
            targetSpeed = rheostartSlider.value / 1.5f;
            amperes = (float)Mathf.Round(targetSpeed * 8f) / 8f;
            amperesReader.text = amperes.ToString() + " " + "A";
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
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, 20.0f);
        }
        SetNeedle();
    }

    void SetNeedle()
    {
        imageNeedle.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 8.0f * 170.334f - 85.167f) * -1.0f);
    }
}
