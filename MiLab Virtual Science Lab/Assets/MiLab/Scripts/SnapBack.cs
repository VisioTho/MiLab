using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBack : MonoBehaviour
{
    Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }

    private void OnMouseUp()
    {
        transform.position = initialPos;
    }
}
