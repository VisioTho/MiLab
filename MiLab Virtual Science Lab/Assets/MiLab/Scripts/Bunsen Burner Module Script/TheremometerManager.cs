using UnityEngine;
using UnityEngine.UI;

public class TheremometerManager : MonoBehaviour, IMercury<float>
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

    public void RiseMercuryLevels(float speed)
    {
        Vector3 tempScale = transform.localScale;
        var V = speed;
        tempScale.y += V;
        transform.localScale = tempScale;
    }
    public void CollapseMercuryLevels(float speed)
    {
        Vector3 tempScale = transform.localScale;
        var V = speed;
        if (tempScale.y >= 1f)
        {
            tempScale.y -= V;
            transform.localScale = tempScale;
        }
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
                        RiseMercuryLevels(0.00002f);
                        break;
                    }

                case 3f:
                    {
                        RiseMercuryLevels(0.0002f);
                        break;
                    }

                case 2f:
                    {
                        RiseMercuryLevels(0.0002f);
                        break;
                    }

                case 1f:
                    {
                        RiseMercuryLevels(0.002f);
                        break;
                    }

                case 0f:
                    {
                        RiseMercuryLevels(0.02f);
                        break;
                    }
            }
        }
        //if flame particle system is not emitting collapse mercury levels
        else
        {
            CollapseMercuryLevels(0.002f);
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
