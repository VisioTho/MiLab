using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillButton : MonoBehaviour
{
    public ChromatographySimulation filledImageController;
    public float fillTime = 2.0f;

    private void Start()
    {

    }

    public void Run()
    {
        filledImageController.fillDuration = fillTime;
        filledImageController.StartFill();
        Debug.Log("filling up");
    }
}
