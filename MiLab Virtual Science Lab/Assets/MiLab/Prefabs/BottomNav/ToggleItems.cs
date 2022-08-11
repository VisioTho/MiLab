using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleItems : MonoBehaviour
{
    public Toggle toggle;

    private void Update()
    {
        if(toggle.isOn)
        {
            gameObject.SetActive(true);
        }
        else if(!toggle.isOn)
        {
            gameObject.SetActive(false);
        }
    }
}
