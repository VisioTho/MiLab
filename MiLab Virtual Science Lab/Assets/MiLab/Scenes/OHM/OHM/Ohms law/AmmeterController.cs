using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmeterController : MonoBehaviour
{
    public SwitchController switchControl;
    public VoltmeterController voltmeterController;

    private const float MAX_SPEED_ANGLE = 9f;
    private const float ZERO_SPEED_ANGLE = 169f;
    public float rot_angle;

    private Transform needleTranform;

    private float speedMax;
    private float speed;

    private void Awake()
    {
        needleTranform = transform.Find("needle");

        speed = 0f;
        speedMax = 200f;
        rot_angle = 0f;
    }

    private void Update()
    {
        HandlePlayerInput();

        //speed += 30f * Time.deltaTime;
        //if (speed > speedMax) speed = speedMax;

        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private void HandlePlayerInput()
    {
        if (switchControl.switch_is_on)
        {
            if (voltmeterController.rheostartSlider.value == 0)
            {
                float acceleration = 0f;
                speed += acceleration * Time.deltaTime;
            }
            if (voltmeterController.rheostartSlider.value == 1)
            {
                float acceleration = 20f;
                speed += acceleration * Time.deltaTime;
                rot_angle = 168f;
            }
            if (voltmeterController.rheostartSlider.value > 0 && switchControl.switch_is_on == false)
            {
                float deceleration = 20f;
                speed -= deceleration * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                float brakeSpeed = 100f;
                speed -= brakeSpeed * Time.deltaTime;
            }

            speed = Mathf.Clamp(speed, 0f, speedMax);
        }
        else
        {
            needleTranform.eulerAngles = new Vector3(0, 0, rot_angle);
        }

    }


    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
