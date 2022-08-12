using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class AmmeterReading : MonoBehaviour
{
    public SwitchController switchControl;
    public MaterialLengthController materialLengthControl;
    public VoltmeterController voltmeterController;
    public Image rotationParent;


    private float duration = 4;

    public TMP_Text ammeterReading;
    void Start()
    {

    }

    private void OnMouseDown()
    {
        //  StartCoroutine(needleRotation(targetRotation));
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
                    transform.DORotate(new Vector3(0, 0, 169.797f), duration);
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    transform.DORotate(new Vector3(0, 0, 145.598f), duration);
                    ammeterReading.text = "0.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    transform.DORotate(new Vector3(0, 0, 128.346f), duration);
                    ammeterReading.text = "0.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    transform.DORotate(new Vector3(0, 0, 111.8f), duration);
                    ammeterReading.text = "0.7 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    transform.DORotate(new Vector3(0, 0, 95.299f), duration);
                    ammeterReading.text = "0.9 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    transform.DORotate(new Vector3(0, 0, 79.367f), duration);
                    ammeterReading.text = "1.1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    transform.DORotate(new Vector3(0, 0, 63.539f), duration);
                    ammeterReading.text = "1.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    transform.DORotate(new Vector3(0, 0, 48.438f), duration);
                    ammeterReading.text = "1.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    transform.DORotate(new Vector3(0, 0, 32.133f), duration);
                    ammeterReading.text = "1.7 A";
                }
                else
                {
                    transform.DORotate(new Vector3(0, 0, 169.797f), 5);
                }
            }
            else if (materialLengthControl.wireAdjustLength.value == 1)
            {
                if (voltmeterController.rheostartSlider.value == 0)
                {
                    transform.DORotate(new Vector3(0, 0, 169.797f), duration);
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    transform.DORotate(new Vector3(0, 0, 154.849f), duration);
                    ammeterReading.text = "0.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    transform.DORotate(new Vector3(0, 0, 136.177f), duration);
                    ammeterReading.text = "0.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    transform.DORotate(new Vector3(0, 0, 120.495f), duration);
                    ammeterReading.text = "0.6 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    transform.DORotate(new Vector3(0, 0, 103.553f), duration);
                    ammeterReading.text = "0.8 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    transform.DORotate(new Vector3(0, 0, 87.444f), duration);
                    ammeterReading.text = "1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    transform.DORotate(new Vector3(0, 0, 71.428f), duration);
                    ammeterReading.text = "1.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    transform.DORotate(new Vector3(0, 0, 56.213f), duration);
                    ammeterReading.text = "1.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    transform.DORotate(new Vector3(0, 0, 40.057f), duration);
                    ammeterReading.text = "1.6 A";
                }
                else
                {
                    transform.DORotate(new Vector3(0, 0, 169.797f), duration);
                }
            }
            else if (materialLengthControl.wireAdjustLength.value == 2)
            {
                if (voltmeterController.rheostartSlider.value == 0)
                {
                    transform.DORotate(new Vector3(0, 0, 169.797f), duration);
                    ammeterReading.text = "0 A";
                }
                if (voltmeterController.rheostartSlider.value == 1)
                {
                    transform.DORotate(new Vector3(0, 0, 161.598f), duration);
                    ammeterReading.text = "0.1 A";
                }
                else if (voltmeterController.rheostartSlider.value == 2)
                {
                    transform.DORotate(new Vector3(0, 0, 154.849f), duration);
                    ammeterReading.text = "0.2 A";
                }
                else if (voltmeterController.rheostartSlider.value == 3)
                {
                    transform.DORotate(new Vector3(0, 0, 145.598f), duration);
                    ammeterReading.text = "0.3 A";
                }
                else if (voltmeterController.rheostartSlider.value == 4)
                {
                    transform.DORotate(new Vector3(0, 0, 136.177f), duration);
                    ammeterReading.text = "0.4 A";
                }
                else if (voltmeterController.rheostartSlider.value == 5)
                {
                    transform.DORotate(new Vector3(0, 0, 128.346f), duration);
                    ammeterReading.text = "0.5 A";
                }
                else if (voltmeterController.rheostartSlider.value == 6)
                {
                    transform.DORotate(new Vector3(0, 0, 120.495f), duration);
                    ammeterReading.text = "0.6 A";
                }
                else if (voltmeterController.rheostartSlider.value == 7)
                {
                    transform.DORotate(new Vector3(0, 0, 111.8f), duration);
                    ammeterReading.text = "0.7 A";
                }
                else if (voltmeterController.rheostartSlider.value == 8)
                {
                    transform.DORotate(new Vector3(0, 0, 103.553f), duration);
                    ammeterReading.text = "0.8 A";
                }
                else
                {
                    transform.DORotate(new Vector3(0, 0, 169.797f), duration);
                }
            }
        }
        if (switchControl.switch_is_on == false)
        {
            transform.DORotate(new Vector3(0, 0, 169.797f), duration);
            ammeterReading.text = "0 A";
        }
    }


}
