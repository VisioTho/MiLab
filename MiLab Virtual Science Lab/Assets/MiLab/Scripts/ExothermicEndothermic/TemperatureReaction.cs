using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;

public class TemperatureReaction : ThermometerBehaviour, IMercury
{
    public ParticleSystem powderParticles;
    private float emissionTime;
    private float stirTime;
    public float temperatureDropRate;
    public TMP_Text tempReading;
    public GameObject[] iceCubes;
    public GameObject iceCube;
    public GameObject water;
    float iceEndPoint;
    float pottasiumEndPointA,pottasiumEndPointB, pottasiumEndPointC;
    Vector3 initialIceCubeScale;

    private void Start()
    {
        iceEndPoint = Random.Range(0.4f, 0.2f);
        pottasiumEndPointA = Random.Range(0.9f, 0.8f);
        pottasiumEndPointB = Random.Range(0.6f, 0.7f);
        pottasiumEndPointC = Random.Range(0.3f, 0.5f);
        initialIceCubeScale = iceCubes[0].transform.lossyScale;
        
    }

    //keep track of how long the theremometer rod is being moved in 'stiring' fashion
    public void CountStirTime()
    {
        if(emissionTime>1f || iceCube.activeSelf)
            stirTime += Time.deltaTime * 1f;
    }
    public void resetStirTime()
    {
        stirTime = 0f;
    }
    public void ResetTemperature()
    {   
        emissionTime = 0f;
        transform.localScale = new Vector2(transform.localScale.x, 1f);
        iceEndPoint = Random.Range(0.4f, 0.2f);
        pottasiumEndPointA = Random.Range(0.9f, 0.8f);
        pottasiumEndPointB = Random.Range(0.6f, 0.7f);
        pottasiumEndPointC = Random.Range(0.3f, 0.5f);
        foreach(GameObject i in iceCubes)
        {
            i.transform.localScale = new Vector3(1f,1f,1f);
        }
        water.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        CountEmissionTime();
        PottasiumNitrateReaction();
        GetThermometerReading();
        IceReaction();
    }

    private void GetThermometerReading()
    {
        tempReading.text = CalculateTemperature().ToString("f0");
    }

    // collapse or rise mercury levels
    private void PottasiumNitrateReaction()
    {
        if (stirTime > 0.4f)
        {
            if (emissionTime > 1f && emissionTime < 4f)
            {
                CollapseMercuryLevels(temperatureDropRate, pottasiumEndPointA);
            }

            else if (emissionTime > 4f && emissionTime < 8f)
            {
                CollapseMercuryLevels(temperatureDropRate, pottasiumEndPointB);
            }
            else if(emissionTime > 8f)
            {
                CollapseMercuryLevels(temperatureDropRate, pottasiumEndPointC);
            }

        }
    }

 
    private void IceReaction()
    {
        if(iceCube.activeSelf==true) // if at least the first ice cube is active
        {
            Debug.Log("ice active");
            if(stirTime>0.4f)
            {
     
                CollapseMercuryLevels(temperatureDropRate, iceEndPoint);
            }
            else
            {
                CollapseMercuryLevels(0.0002f, 0.4f);
                foreach(GameObject i in iceCubes)
                {
                    i.LeanScaleX(0f, 60f);
                    i.LeanScaleY(0f, 60f);
                }
 
            }
        }
    }

    public void MeltIceCubes()
    {
        if (iceCube.activeSelf)
        {
            for (int i = 0; i < iceCubes.Length; i++)
            {
                iceCubes[i].LeanScaleX(0f, 20f);
                iceCubes[i].LeanScaleY(0f, 20f);
            }
        }
        
    }

    //keep track of how long the poweder particles have been emitting
    private void CountEmissionTime()
    {
        if (powderParticles.isEmitting)
        {
            emissionTime += Time.deltaTime * 1f;
        }
    }
}
