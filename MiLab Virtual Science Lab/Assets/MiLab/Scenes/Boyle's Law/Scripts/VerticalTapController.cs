using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTapController : MonoBehaviour
{
    Vector2 initialPosition;
    public float tapEndPoint;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if(transform.position.x > initialPosition.x)
        {
            transform.position = initialPosition;
        }

        if(transform.position.x < tapEndPoint)
        {
            transform.position = new Vector2(tapEndPoint, initialPosition.y);
        }
    }
}
