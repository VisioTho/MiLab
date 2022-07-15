using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BeakerRotation : MonoBehaviour
{
    public LiquidControllerScript liquidControllerScript;
    public Quaternion currentRotation;
    public Quaternion targetRotation;
    public SpriteRenderer rotationParent;
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
        rotationParent.transform.DORotate(new Vector3(0, 0, 47.432f), 1f);
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
        rotationParent.transform.DORotate(new Vector3(0, 0, 0f), 2f);
        liquidControllerScript.stopFlow();
        liquidControllerScript.beakerToggle.interactable = true;
    }

}
