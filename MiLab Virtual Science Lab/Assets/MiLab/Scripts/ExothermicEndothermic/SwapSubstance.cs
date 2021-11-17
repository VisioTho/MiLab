using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSubstance : MonoBehaviour
{
    public GameObject[] substanceA;
    public GameObject[] substanceB;
    public ToggleGroup toggleGroup;
    private Toggle activeToggle;

    //handle selection from dropdown list
    private void Update()
    {
        SwapSubstanceA();
    }

    //change substance based on radio group state
    private void SwapSubstanceA()
    {   
        activeToggle = toggleGroup.GetFirstActiveToggle();

        if(activeToggle.name=="PotassiumNitrate")
        {
            ShowSubstance(0);
        }

        else if (activeToggle.name == "Ice")
        {
            ShowSubstance(1);
        }

        else if (activeToggle.name == "SodiumHydroxide")
        {
            ShowSubstance(2);
        }
    }
   

    //show substance selected from radio group and hide the rest of the items
    private void ShowSubstance(int n)
    {
        substanceA[n].SetActive(true);
        for (int i = 0; i < substanceA.Length; i++)
        {
            if (i != n) substanceA[i].SetActive(false);
        }
    }
}
