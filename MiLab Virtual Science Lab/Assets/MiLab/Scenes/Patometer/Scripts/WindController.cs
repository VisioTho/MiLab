using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour
{
    public bool isBlowingWind;
    
    public void ToggleWind()
    {
        if (!GetComponent<Toggle>().isOn)
        {
            isBlowingWind = false;
        }
        else if(GetComponent<Toggle>().isOn)
        {
            isBlowingWind = true;
        }
    }

    private void Update()
    {
        WaterLevelManager.BlowWind(this);
    }
}
