using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
    private float lastClickTime = 0f;
    private float doubleClickTimeThreshold = 0.2f;

    public bool doubleTap;

    void OnMouseDown() {
        if (Time.time - lastClickTime < doubleClickTimeThreshold) {
            // Double click detected
            doubleTap = true;
            
        } else {
            // Single click detected
            doubleTap = false;
        }
        lastClickTime = Time.time;
    }
}
