using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FanController : MonoBehaviour
{
    public float rotateSpeed; // Rotation speed in degrees per second
    public bool canRotate = true; // Boolean to control rotation
    public DialSwicth dialSwicth;

    void Update()
    {
        if (dialSwicth.isRotated)
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime); // Rotate the object on the z-axis continuously
        }
    }
}
