using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropping : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drop_to_spawn, spawn_pointA;

    public void OnMouseDown()
    {
        Instantiate(drop_to_spawn, spawn_pointA.transform.position, Quaternion.identity);
    }
}