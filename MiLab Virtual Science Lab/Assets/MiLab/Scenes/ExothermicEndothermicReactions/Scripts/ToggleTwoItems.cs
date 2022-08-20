using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTwoItems : MonoBehaviour
{
    public GameObject itemOne, itemTwo;
    private Toggle toggle;
    private void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
    }

    private void Update()
    {
        if(toggle.isOn)
        {
            itemOne.SetActive(true);
            itemTwo.SetActive(false);
        }
        if(!toggle.isOn)
        {
            itemOne.SetActive(false);
            itemTwo.SetActive(true);
        }
    }
}
