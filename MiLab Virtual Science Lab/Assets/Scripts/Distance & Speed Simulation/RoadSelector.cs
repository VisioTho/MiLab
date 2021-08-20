using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSelector : MonoBehaviour
{
    [SerializeField] private GameObject flatRoad, hillyRoad;
    public void SelectRoad(int val)
    {
        if(val == 0)
        {
            flatRoad.SetActive(true);
            hillyRoad.SetActive(false);
        }
        if(val == 1)
        {
            flatRoad.SetActive(false);
            hillyRoad.SetActive(true);
        }
    }
}
