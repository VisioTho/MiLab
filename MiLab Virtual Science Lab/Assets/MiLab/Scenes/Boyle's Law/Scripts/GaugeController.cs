using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GaugeController : MonoBehaviour
{
    public GameObject oil;
    public TMP_Text pressureDisplayText;
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

    float pressure;
    private void Update()
    {
        Debug.Log(transform.rotation.z + " is the rotation");
        pressure = (0.5737163f /transform.rotation.z) * 140.0f;
        pressureDisplayText.text = pressure.ToString("f0");
        oilScale = oil.transform.localScale.y;
        transform.eulerAngles = new Vector3(0, 0, GaugeScaleConverter());     
        
    }

}
