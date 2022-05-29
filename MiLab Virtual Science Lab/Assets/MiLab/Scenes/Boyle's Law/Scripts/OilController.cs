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
       
        bool isDragged = PumpController.isDragged;
        

        if (PumpController.isPumped)
            //RiseMercuryLevels(0.01f, 7f);

        if(gasTap.transform.position.x < 1.276372f)
        {
            //CollapseMercuryLevels(0.009f, initialScale.y);
        }
    }
}
