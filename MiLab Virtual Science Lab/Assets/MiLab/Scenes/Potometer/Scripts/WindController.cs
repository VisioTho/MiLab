using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour
{
    public bool isBlowingWind;
    public DialSwicth dialSwicth;
    
    void ToggleWind()
    {
        if(dialSwicth.isRotated)
        {
            isBlowingWind = true;
        }
        else
        {
            isBlowingWind = false;
        }
    }

    private void Update()
    {
        ToggleWind();
        BubbleController.BlowWind(this);
    }
}
