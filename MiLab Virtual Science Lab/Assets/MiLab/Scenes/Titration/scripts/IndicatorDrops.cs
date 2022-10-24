using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorDrops : MonoBehaviour
{

    [SerializeField] private GameObject[] indicatorDrops;
    int dropsCount;


    public void Indicator()
    {
        dropsCount = 0;
        foreach (GameObject i in indicatorDrops)
        {
            if (i.activeSelf)
            {
                dropsCount++;
            }

        }

        if (indicatorDrops[0].activeSelf && dropsCount == 1)
        {
            indicatorDrops[1].SetActive(true);
        }
        else if (indicatorDrops[1].activeSelf && dropsCount == 2)
        {
            indicatorDrops[2].SetActive(true);
        }
        else if (indicatorDrops[2].activeSelf && dropsCount == 3)
        {
            indicatorDrops[3].SetActive(true);
        }
        else if (indicatorDrops[3].activeSelf && dropsCount == 4)
        {
            indicatorDrops[4].SetActive(true);
        }
        else
            indicatorDrops[0].SetActive(true);

    }
}
