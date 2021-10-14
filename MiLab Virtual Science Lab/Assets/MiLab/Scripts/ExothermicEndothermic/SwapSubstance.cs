using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSubstance : MonoBehaviour
{
    public GameObject[] substanceA;
    public GameObject[] substanceB;
    public void SwapSubstanceA(int val)
    {
        if (val == 0)
        {
            ShowSubstance(0);
        }
        else if (val == 1)
        {
            ShowSubstance(1);
        }
        else if(val == 2)
        {
            ShowSubstance(2);
        }


    }

    private void ShowSubstance(int n)
    {
        substanceA[n].SetActive(true);
        for (int i = 0; i < substanceA.Length; i++)
        {
            if (i != n) substanceA[i].SetActive(false);
        }
    }
}
