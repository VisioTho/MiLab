using UnityEngine;
using UnityEngine.UI;

public class TheremometerManager : MonoBehaviour
{
    private Vector2 scaleChange = new Vector2(0.0f, 1.0f);
    private Vector3 temp;
   
    public Slider gasValveSlider, airHoleSlider;
    
    public ParticleSystem flame;
    
    public ParticleSystem bubbles;
    

    void Start()
    {
        bubbles.Stop();
    }
    void FixedUpdate()
    {
        ControlTemperatureLevels();
    }

    private void ControlTemperatureLevels()
    {
        // local reference to scale of mercury object 
        temp = transform.localScale;

        if (this.transform.localScale.y > 4.5f)
        {
            temp.y = 4.5f;
            transform.localScale = temp;
        }

        //control levels of mercury
        if (flame.isEmitting && this.transform.localScale.y < 4.5f)
        {
            switch (airHoleSlider.value)
            {
                case 4f:
                    {
                        const float V = 0.00002f;
                        temp.y += V;
                        transform.localScale = temp;
                        break;
                    }

                case 3f:
                    {
                        const float V = 0.0002f;
                        temp.y += V;
                        transform.localScale = temp;
                        break;
                    }

                case 2f:
                    {
                        const float V = 0.0002f;
                        temp.y += V;
                        transform.localScale = temp;
                        break;
                    }

                case 1f:
                    {
                        const float V = 0.002f;
                        temp.y += V;
                        transform.localScale = temp;
                        break;
                    }

                case 0f:
                    {
                        float V = 0.02f;
                        temp.y += V;
                        transform.localScale = temp;
                        break;
                    }
            }
        }
        //if flame particle system is not emitting collapse mercury levels
        else
        {
            const float V = 0.02f;
            if (temp.y >= 1f)
            {
                temp.y -= V;
                transform.localScale = temp;
            }
        }

        if (temp.y >= 3f)
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
        if (!bubbles.isEmitting)
            bubbles.Play();
    }

    private void coolWater()
    {
        if (bubbles.isEmitting)
            bubbles.Stop();
    }
}
