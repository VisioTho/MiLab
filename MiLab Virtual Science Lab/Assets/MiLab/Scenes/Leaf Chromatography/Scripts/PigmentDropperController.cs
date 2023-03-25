using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigmentDropperController : MonoBehaviour
{
    public GameObject drop_to_spawn, spawn_pointA;


    public void OnMouseDown()
    {
        Debug.Log("Touched");
        if (SnapController.snapEnabled)
        {
            Instantiate(drop_to_spawn, spawn_pointA.transform.position, Quaternion.identity);

        }
    }
}
