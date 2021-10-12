using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureReaction : MonoBehaviour, IMercury<float>
{
    public ParticleSystem powderParticles;
    private float emissionTime;
    private float stirTime;
    public GameObject theremometerRod;
    private float temperatureDrop=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (tempScale.y >= temperatureDrop)
        {
            tempScale.y -= V;
            transform.localScale = tempScale;
        }
    }

    public void CountDurationOfDrag()
    {
        if(emissionTime>1f)
            stirTime += Time.deltaTime * 1f;
        Debug.Log(stirTime);
    }

    // Update is called once per frame
    void Update()
    {
        CountEmissionTime();

        if (stirTime > 0.3f && emissionTime>1f)
        {
            temperatureDrop = 0.5f;
            CollapseMercuryLevels(0.0002f);
        }

        if (stirTime > 0.3f && emissionTime > 2f)
        {
            temperatureDrop = 0.3f;
            CollapseMercuryLevels(0.002f);
        }

    }

    private void CountEmissionTime()
    {
        if (powderParticles.isEmitting)
        {
            emissionTime += Time.deltaTime * 1f;
        }
    }
}
