using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{
    public SnapPoints SnapPoints;
    public SnapToSpecificPoint lens;
    public SnapToSpecificPoint screen;

    GameObject[] snapPoints;

    void Start()
    {
        snapPoints = SnapPoints.GetArray();
    }
    
    void Update()
    {
        if(lens.currentConnectionPoint == snapPoints[3] && screen.currentConnectionPoint == snapPoints[6])
        {
            Debug.Log("afika");       
        }
    }
}
