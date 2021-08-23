using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------Script Summary--------------------------------*/
/* This script controls the theremometer mercury image scaling. Depending on
size and strength of the flame particle system. Additionally, boiling bubble 
particle system is controlled by this script
/*----------------------------------------------------------------------------*/

public class TheremometerManager : MonoBehaviour
{
    private Vector2 scaleChange = new Vector2(0.0f, 1.0f);
    private Vector3 temp;
    //reference to the air holes and gas valve slider in scene
    [SerializeField] private Slider gasValveSlider, airHoleSlider;
    //reference to flame particle system
    [SerializeField] private ParticleSystem flame;
    //reference to boiling water particles
    [SerializeField] private ParticleSystem bubbles;
    // Update is called once per frame
   
   void Start()
   {
       // do not emit particles on wake
      bubbles.Stop();
   }
    void FixedUpdate()
    { 
        // reference to scale of mercury object 
        temp = transform.localScale;
        
        /* this block of if statements controls the rising or falling of the mercury levels 
        according to strength of the flame (flame particle color)*/
        if(this.transform.localScale.y>4.5f)
            {
                temp.y = 4.5f;
                transform.localScale = temp;
            }

        if(flame.isEmitting && this.transform.localScale.y<4.5f)
        {
            if(airHoleSlider.value==4f)
                {
                    const float V = 0.00002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==3f)
                {
                    const float V = 0.0002f;
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
                    const float V = 0.002f;
                    temp.y += V;
                    transform.localScale = temp;
                }
                else if(airHoleSlider.value==0f)
                {
                    float V = 0.02f;
                    temp.y += V;
                    transform.localScale = temp;
                }
        }
        //if flame particle system is not emitting collapse mercury levels
        else 
        {
            const float V = 0.02f;
            if(temp.y>=1f)
                {
                    temp.y -= V;
                    transform.localScale = temp;
                }
        }

        if(temp.y>=3f)
        {
            boilWater();
        }
        else
            {
                coolWater();
            } 
        
    }

    private void boilWater()
    {
        if(!bubbles.isEmitting)
            bubbles.Play(); 
    }

    private void coolWater()
    {
        if(bubbles.isEmitting)
            bubbles.Stop();
    }
}
