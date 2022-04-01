using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class ChemicalFormulaDisplay : MonoBehaviour
{
    //set public fields in inspector
    public GameObject[] reactionSetA, reactionSetB, reactionSetC;
    public GameObject substanceA, substanceB, substanceC;
    

    private void Update()
    {
        DisplayFormula(); Debug.Log("DIsplayFormula");
    }
    //display chemical formula according to ToggleGroup selection
    public void DisplayFormula()
    {
        if (substanceA.activeSelf)
        {
            ShowChemicalFormula(reactionSetA);
            HideChemicalFormula(reactionSetC);
            HideChemicalFormula(reactionSetB);
        }
        else if (substanceB.activeSelf)
        {
            ShowChemicalFormula(reactionSetB);
            HideChemicalFormula(reactionSetC);
            HideChemicalFormula(reactionSetA);
        }
        else if (substanceC.activeSelf)
        {
            ShowChemicalFormula(reactionSetC);
            HideChemicalFormula(reactionSetB);
            HideChemicalFormula(reactionSetA);
        }
    }

    //show selected formula
    private void ShowChemicalFormula(GameObject[] array)
    {
        foreach (GameObject i in array)
        {
            i.SetActive(true);
        }
    }

    //hide selected formula
    private void HideChemicalFormula(GameObject[] array)
    {
        foreach (GameObject i in array)
        {
            i.SetActive(false);
        }
    }
}
