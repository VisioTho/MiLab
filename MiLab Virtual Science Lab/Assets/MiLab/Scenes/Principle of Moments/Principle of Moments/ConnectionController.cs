using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionController : MonoBehaviour
{
    public Collider2D[] lConnectionPoints, rConnectionPoints;

    private void Start()
    {
        MassManager.lConnectionPoints = lConnectionPoints;
        MassManager.rConnectionPoints = rConnectionPoints;
    }
}
