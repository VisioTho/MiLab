using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChemicalFormulaDisplay : MonoBehaviour
{
    public TMP_Dropdown substanceSelector;
    public GameObject[] formulaTiles;
    
    public void DisplayFormula(int val)
    {
        if(val == 0)
        {
            formulaTiles[0].SetActive(true);
            formulaTiles[1].SetActive(true);
            formulaTiles[2].SetActive(true);
            formulaTiles[3].SetActive(true);
            formulaTiles[4].SetActive(false);
        }
        else if(val == 1)
        {
            for(int i=0; i<formulaTiles.Length; i++)
            {
                if (i == 3 || i==4)
                    formulaTiles[i].SetActive(true);
                else
                    formulaTiles[i].SetActive(false);
            }
        }
    }
}
