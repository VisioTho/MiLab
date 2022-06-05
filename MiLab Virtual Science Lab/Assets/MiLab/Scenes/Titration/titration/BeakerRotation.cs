using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeakerRotation : MonoBehaviour
{
    public LiquidControllerScript liquidControllerScript;
    public Quaternion currentRotation;
    public Quaternion targetRotation;
    public GameObject rotationParent;
    public float rot_duration;
    public float z_rotation_angle;

    void Start()
    {
        rot_duration = 1f;
        z_rotation_angle = 0;
    }
    void OnMouseDown()
    {

        if (liquidControllerScript.fill.currentVal >= liquidControllerScript.fill.MaxVal)
        {
            // Invoke("beakerRotation", 0.5f);
            Debug.Log("oops");
        }
        else
        {
            Invoke("beakerRotation", 0.5f);
        }

    }

    public void beakerRotation()
    {
        Vibration.Vibrate(30);
        z_rotation_angle = 47.432f;
        targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
        StartCoroutine(beakerRotation(targetRotation));
        liquidControllerScript.Invoke("fillUp", 1);
        liquidControllerScript.Invoke("startFillDelay", 1);
        liquidControllerScript.beakerToggle.interactable = false;
    }

    private void OnMouseUp()
    {
        CancelInvoke("beakerRotation");
        Invoke("resetBeakerPosition", 1);
    }

    public void resetBeakerPosition()
    {
        z_rotation_angle = 0;
        targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
        StartCoroutine(beakerRotation(targetRotation));
        liquidControllerScript.stopFlow();
        liquidControllerScript.beakerToggle.interactable = true;
    }

    IEnumerator beakerRotation(Quaternion targetRotation)
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
