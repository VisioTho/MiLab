using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmeterReading : MonoBehaviour
{
    public SwitchController switchControl;
    public VoltmeterController voltmeterController;
    public Quaternion currentRotation;
    public Quaternion targetRotation;
    public GameObject rotationParent;
    public static float rot_duration;
    public static float z_rotation_angle;

    public TMP_Text ammeterReading;
    void Start()
    {
        rot_duration = 1f;
        z_rotation_angle = 0f;
    }

    private void OnMouseDown()
    {
        StartCoroutine(needleRotation(targetRotation));
    }

    // Update is called once per frame
    void Update()
    {

        if (switchControl.switch_is_on == true)
        {
            if (voltmeterController.rheostartSlider.value == 0)
            {
                z_rotation_angle = 84.289f;
                ammeterReading.text = "0 A";
            }
            if (voltmeterController.rheostartSlider.value == 1)
            {
                z_rotation_angle = 60.166f;
                ammeterReading.text = "0.3 A";
            }
            else if (voltmeterController.rheostartSlider.value == 2)
            {
                z_rotation_angle = 42.106f;
                ammeterReading.text = "0.5 A";
            }
            else if (voltmeterController.rheostartSlider.value == 3)
            {
                z_rotation_angle = 24.438f;
                ammeterReading.text = "0.7 A";
            }
            else if (voltmeterController.rheostartSlider.value == 4)
            {
                z_rotation_angle = 7.325f;
                ammeterReading.text = "0.9 A";
            }
            else if (voltmeterController.rheostartSlider.value == 5)
            {
                z_rotation_angle = -10.528f;
                ammeterReading.text = "1.1 A";
            }
            else if (voltmeterController.rheostartSlider.value == 6)
            {
                z_rotation_angle = -28.04f;
                ammeterReading.text = "1.3 A";
            }
            else if (voltmeterController.rheostartSlider.value == 7)
            {
                z_rotation_angle = -44.371f;
                ammeterReading.text = "1.5 A";
            }
            else if (voltmeterController.rheostartSlider.value == 8)
            {
                z_rotation_angle = -61.776f;
                ammeterReading.text = "1.7 A";
            }
            else
            {
                z_rotation_angle = 84.289f;
            }
            targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
            StartCoroutine(needleRotation(targetRotation));
        }
        if (switchControl.switch_is_on == false)
        {
            z_rotation_angle = 84.289f;
            targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
            StartCoroutine(needleRotation(targetRotation));
        }
    }

    IEnumerator needleRotation(Quaternion targetRotation)
    {
        float rot_time = 0;
        Quaternion startRotation = rotationParent.transform.rotation;
        while (rot_time < rot_duration)
        {
            rotationParent.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rot_time / rot_duration);
            rot_time += Time.deltaTime;
            yield return null;
        }
        rotationParent.transform.rotation = targetRotation;
        rot_time = 0;
    }
}
