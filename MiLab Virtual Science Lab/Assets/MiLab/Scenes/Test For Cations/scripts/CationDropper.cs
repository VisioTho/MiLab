using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CationDropper : MonoBehaviour
{
    public GameObject drop_to_spawn, spawn_pointA;


    public void OnMouseDown()
    {
        Instantiate(drop_to_spawn, spawn_pointA.transform.position, Quaternion.identity);
    }


}
