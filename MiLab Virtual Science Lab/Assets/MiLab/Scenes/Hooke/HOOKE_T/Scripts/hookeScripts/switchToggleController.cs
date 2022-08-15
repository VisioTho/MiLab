using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchToggleController : MonoBehaviour
{
    public GameObject bulb, ammeter_reads, ammeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
