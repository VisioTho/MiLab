using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    public Sprite switchOn;
    public Sprite switchOff;
    public MaterialLengthController materialLength;
    public bool switch_is_on = false;

    public void OnMouseDown()
    {
        Debug.Log("pressed");
        if (switch_is_on)
        {
            switch_is_on = false;
        }
        else
        {
            switch_is_on = true;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (switch_is_on)
        {
            Debug.Log("switch turned on");
            gameObject.GetComponent<Image>().sprite = switchOn;
            materialLength.wireAdjustLength.interactable = false;
        }
        else
        {
            Debug.Log("Switch turned off");
            gameObject.GetComponent<Image>().sprite = switchOff;
            materialLength.wireAdjustLength.interactable = true;
        }
    }


}
