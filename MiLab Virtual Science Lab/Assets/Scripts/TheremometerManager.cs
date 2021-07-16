using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheremometerManager : MonoBehaviour
{
/*-----------------------------Script Summary--------------------------------*/
/* This script controls the theremometer mercutry image scaling. Depending on
size and strength of the flame particle system.
/*----------------------------------------------------------------------------*/
    private Vector2 scaleChange = new Vector2(0.0f, 1.0f);
    private Vector3 temp;
    [SerializeField] private Slider gasValveSlider, airHoleSlider;
    [SerializeField] private ParticleSystem flame;
    // Update is called once per frame
   
    void Update()
    { 
        temp = transform.localScale;
        if(flame.isEmitting && temp.y<=4.6f)
        {
            if(airHoleSlider.value==4f)
                {
                    const float V = 0.00002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==3f)
                {
                    const float V = 0.00002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==2f)
                {
                    const float V = 0.0002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==1f)
                {
                    const float V = 0.0002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==0f)
                {
                    const float V = 0.002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
            }
        else 
        {
            const float V = 0.02f;
            if(temp.y>=1f)
                {
                    temp.y -= V;
                    transform.localScale = temp;
                }
        }
        
    }
}
