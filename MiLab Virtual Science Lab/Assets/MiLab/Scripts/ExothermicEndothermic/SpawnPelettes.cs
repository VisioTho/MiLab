using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPelettes : MonoBehaviour
{
    [SerializeField] private GameObject[] pelettes;
    int peletteCount;


    public void Spawn()
    {
        peletteCount = 0;
        foreach (GameObject i in pelettes)
        {
            if (i.activeSelf)
                peletteCount++;
        }

        if (pelettes[0].activeSelf && peletteCount == 1)
        {
            pelettes[1].SetActive(true);
        }
        else if (pelettes[1].activeSelf && peletteCount == 2)
        {
            pelettes[2].SetActive(true);
        }
        else
            pelettes[0].SetActive(true);
            
    }
}
