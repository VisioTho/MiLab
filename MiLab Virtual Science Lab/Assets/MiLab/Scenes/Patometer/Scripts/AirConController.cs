using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirConController : MonoBehaviour
{
    public bool isCooling;
    public TMP_Text airConText;

    public void ToggleAirCon()
    {
        if (!GetComponent<Toggle>().isOn)
        {
            isCooling = false;
        }
        else if (GetComponent<Toggle>().isOn)
        {
            isCooling = true;
        }
    }

    private void Update()
    {
        WaterLevelManager.CoolRoom(this);
        if(isCooling)
        {
            airConText.text = "14";
        }
        else
        {
            airConText.text = "24";
        }
    }

}
