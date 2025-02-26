using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LrSetPoints : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineRendererController line;

    private void Start()
    {
        line.SetUpPoints(points);
    }

}
