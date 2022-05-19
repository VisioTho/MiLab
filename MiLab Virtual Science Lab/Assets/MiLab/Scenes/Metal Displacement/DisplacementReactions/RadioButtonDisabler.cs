using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonDisabler : MonoBehaviour
{
    public Toggle copperMetalRadio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void DisableRadioButton()
    {
        copperMetalRadio.interactable = false;
    }
}
