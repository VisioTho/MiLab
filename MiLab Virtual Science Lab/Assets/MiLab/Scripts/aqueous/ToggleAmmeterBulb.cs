using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAmmeterBulb : MonoBehaviour
{
    public GameObject bulb, ammeter;
    
    public void ToggleEquipment()
    {
        if(gameObject.GetComponent<Toggle>().isOn)
        {
            ammeter.SetActive(false);
            bulb.SetActive(true);
        }
        else
        {
            ammeter.SetActive(true);
            bulb.SetActive(false);
        }
    }

    public void ToggleAmmeterOrBulb()
    {
        ToggleEquipment();
    }
}
