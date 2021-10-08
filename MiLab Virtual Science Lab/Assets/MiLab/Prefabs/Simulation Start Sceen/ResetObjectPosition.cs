using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    GameObject apparatus;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.gameObject.transform.position;
        apparatus = this.gameObject;
    }

    private void FixedUpdate()
    {
        Debug.Log("hello");
        if (apparatus.activeSelf == false)
        {
            Debug.Log("object");
            gameObject.transform.position = initialPosition;
        }
    }
}
