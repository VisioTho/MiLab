using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    public GameObject oil;
    private const float MAX_ANGLE = -20f;
    private const float MIN_ANGLE = 90f;

    private float oilScale, maxOilScale;

    private void Start()
    {
        maxOilScale = 7f;
    }
    private float GaugeScaleConverter()
    {
        float totalAngleSize = MAX_ANGLE - MIN_ANGLE;
        float oilScaleNormalized = oilScale / maxOilScale;


        return MIN_ANGLE + totalAngleSize * oilScaleNormalized;
    }

    private void Update()
    {

        oilScale = oil.transform.localScale.y;
        transform.eulerAngles = new Vector3(0, 0, GaugeScaleConverter());     
        
    }

}
