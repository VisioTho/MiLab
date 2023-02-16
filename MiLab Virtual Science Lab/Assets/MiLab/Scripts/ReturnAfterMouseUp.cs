using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAfterMouseUp : MonoBehaviour
{
    private bool mouseUp, mouseDown;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;   
    }

    private void OnMouseDown()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }


}
