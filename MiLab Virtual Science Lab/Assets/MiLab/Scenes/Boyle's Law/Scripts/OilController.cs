using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : ThermometerBehaviour
{
    public GameObject gasTap;
    private Vector3 initialPosTap;
    private Vector3 initialScale;
    [SerializeField] private float maxHeight;
    private void Start()
    {
        initialPosTap = transform.position;
        initialScale = transform.localScale;
    }
    private void Update()
    {
        float offsetAfterRelease = PumpController.offsetAfterRelease;
        bool isDragged = PumpController.isDragged;
        

        if (offsetAfterRelease > 0f && isDragged)
            RiseMercuryLevels(0.02f, maxHeight);

        if(gasTap.transform.position.x < 1.276372f)
        {
            CollapseMercuryLevels(0.002f, initialScale.y);
        }
    }
}
