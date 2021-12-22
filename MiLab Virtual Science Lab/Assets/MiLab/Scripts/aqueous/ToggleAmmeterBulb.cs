using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAmmeterBulb : MonoBehaviour
{
    public GameObject bulb, ammeter_reads, ammeter;
    
    public void ToggleEquipment()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            ammeter.SetActive(false);
            ammeter_reads.SetActive(false);
            bulb.SetActive(true);
        }
        else
        {
            ammeter.SetActive(true);
            ammeter_reads.SetActive(true);
            bulb.SetActive(false);
        }
    }

    public void ToggleAmmeterOrBulb()
    {
        ToggleEquipment();
    }
}
