using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_restrictor : MonoBehaviour
{
    public Vector3 default_position;
    // Start is called before the first frame update
    void Start()
    {
        default_position = gameObject.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = default_position; 
    }
}
