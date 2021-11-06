using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorDropdown : MonoBehaviour
{
    [SerializeField] TMP_Text dropdownText;

    public void handleIndicatorDropdown(int val)
    {
        if (val == 0)
        {
            dropdownText.text = "Phenolphlaine is colorless when pH is below 8.2 and pink when pH is above 8.2";
        }
        if (val == 1)
        {
            dropdownText.text = "--- ---";
        }
        if (val == 2)
        {
            dropdownText.text = "--- ---";
        }
    }

}
