using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLaser : MonoBehaviour
{
    private LineRenderer Line;
    public Transform hitPoint;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        //Line.enabled = false;
        Line.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        hitPoint.position = hit.point;
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, hitPoint.position);

    }
}
