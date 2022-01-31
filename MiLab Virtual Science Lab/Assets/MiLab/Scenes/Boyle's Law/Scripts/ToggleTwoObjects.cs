using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTwoObjects : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    public void ToggleItemsActive()
    {
        if (objects[0].activeSelf)
        {
            objects[1].SetActive(true);
            objects[0].SetActive(false);
        }
            
        else
        {
            objects[0].SetActive(true);
            objects[1].SetActive(false);
        }
            
    }
}
