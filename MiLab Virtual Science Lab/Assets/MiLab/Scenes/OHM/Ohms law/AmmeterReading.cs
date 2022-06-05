using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmeterReading : MonoBehaviour
{
    public SwitchController switchControl;
    public MaterialLengthController materialLengthControl;
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
            if (materialLengthControl.wireAdjustLength.value == 0)
            {
                if (voltmeterController.rheostartSlider.value == 0)
                {
                    z_rotation_angle = 169.797f;
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    z_rotation_angle = 145.598f;
                    ammeterReading.text = "0.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    z_rotation_angle = 128.346f;
                    ammeterReading.text = "0.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    z_rotation_angle = 111.8f;
                    ammeterReading.text = "0.7 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    z_rotation_angle = 95.299f;
                    ammeterReading.text = "0.9 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    z_rotation_angle = 79.367f;
                    ammeterReading.text = "1.1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    z_rotation_angle = 63.539f;
                    ammeterReading.text = "1.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    z_rotation_angle = 48.438f;
                    ammeterReading.text = "1.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    z_rotation_angle = 32.133f;
                    ammeterReading.text = "1.7 A";
                }
                else
                {
                    z_rotation_angle = 169.797f;
                }
            }
            else if (materialLengthControl.wireAdjustLength.value == 1)
            {
                if (voltmeterController.rheostartSlider.value == 0)
                {
                    z_rotation_angle = 169.797f;
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    z_rotation_angle = 154.849f;
                    ammeterReading.text = "0.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    z_rotation_angle = 136.177f;
                    ammeterReading.text = "0.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    z_rotation_angle = 120.495f;
                    ammeterReading.text = "0.6 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    z_rotation_angle = 103.553f;
                    ammeterReading.text = "0.8 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    z_rotation_angle = 87.444f;
                    ammeterReading.text = "1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    z_rotation_angle = 71.428f;
                    ammeterReading.text = "1.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    z_rotation_angle = 56.213f;
                    ammeterReading.text = "1.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    z_rotation_angle = 40.057f;
                    ammeterReading.text = "1.6 A";
                }
                else
                {
                    z_rotation_angle = 169.797f;
                }
            }
            else if (materialLengthControl.wireAdjustLength.value == 2)
            {
                if (voltmeterController.rheostartSlider.value == 0)
                {
                    z_rotation_angle = 169.797f;
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    z_rotation_angle = 161.598f;
                    ammeterReading.text = "0.1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    z_rotation_angle = 154.849f;
                    ammeterReading.text = "0.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    z_rotation_angle = 145.598f;
                    ammeterReading.text = "0.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    z_rotation_angle = 136.177f;
                    ammeterReading.text = "0.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    z_rotation_angle = 128.346f;
                    ammeterReading.text = "0.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    z_rotation_angle = 120.495f;
                    ammeterReading.text = "0.6 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    z_rotation_angle = 111.8f;
                    ammeterReading.text = "0.7 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    z_rotation_angle = 103.553f;
                    ammeterReading.text = "0.8 A";
                }
                else
                {
                    z_rotation_angle = 169.797f;
                }
            }

            targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
            StartCoroutine(needleRotation(targetRotation));
        }
        if (switchControl.switch_is_on == false)
        {
            z_rotation_angle = 169.797f;
            targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
            StartCoroutine(needleRotation(targetRotation));
            ammeterReading.text = "0 A";
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
       // rot_time = 0;
    }
}
