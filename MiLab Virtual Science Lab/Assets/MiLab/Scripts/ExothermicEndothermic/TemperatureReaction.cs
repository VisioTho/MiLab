using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using UnityEngine.UI;

public class TemperatureReaction : ThermometerBehaviour, IMercury
{
    public ParticleSystem powderParticles;
    private float emissionTime;
    private float stirTime;
    public float temperatureDropRate;
    public TMP_Text tempReading;
    public GameObject[] iceCubes;
    public GameObject sodiumPelletes;
    public GameObject[] pellets;
    public GameObject iceCube;
    public GameObject water;
    float iceEndPoint;
    float pottasiumEndPointA,pottasiumEndPointB, pottasiumEndPointC; //randomized final temperature value after reaction for each substance

    private void Start()
    {
        iceEndPoint = Random.Range(0.4f, 0.2f);
        pottasiumEndPointA = Random.Range(0.9f, 0.8f);
        pottasiumEndPointB = Random.Range(0.6f, 0.7f);
        pottasiumEndPointC = Random.Range(0.3f, 0.5f);
        transform.localScale = new Vector2(1f, Random.Range(0.9f, 1.1f));
    }

    //keep track of how long the theremometer rod is being moved in 'stiring' fashion
    public void CountStirTime()
    {
        if(emissionTime>1f || iceCube.activeSelf || sodiumPelletes.activeSelf)
            stirTime += Time.deltaTime * 1f;
    }
    public void resetStirTime()
    {
        stirTime = 0f;
    }
    public void ResetTemperature()
    {
        emissionTime = 0f;
        resetStirTime();

        transform.localScale = new Vector2(transform.localScale.x, 1f);
        transform.localScale = new Vector2(1f, Random.Range(0.9f, 1.1f));
        iceEndPoint = Random.Range(0.4f, 0.2f);
        pottasiumEndPointA = Random.Range(0.9f, 0.8f);
        pottasiumEndPointB = Random.Range(0.6f, 0.7f);
        pottasiumEndPointC = Random.Range(0.3f, 0.5f);
        ResetSizeAndPosition(iceCubes);
        ResetSizeAndPosition(pellets);
        water.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void ResetSizeAndPosition(GameObject[] objects)
    {
        foreach (GameObject i in objects)
        {
            i.transform.LeanScaleY(1f, 1f);
            i.transform.LeanScaleX(1f, 0f);
            i.transform.LeanMoveLocalY(1f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountEmissionTime();
        PottasiumNitrateReaction();
        GetThermometerReading();
        IceReaction();
        SodiumHydroxideReaction();
    }

    private void GetThermometerReading()
    {
        tempReading.text = CalculateTemperature().ToString("f0");
    }

    //how temperature changes when potassium reacts with the water
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

    //how temperature changes when ice reacts with liquid water
    private void IceReaction()
    {
        if(iceCube.activeSelf==true) // if at least the first ice cube is active
        {
            if(stirTime>0.4f)
            {
                CollapseMercuryLevels(temperatureDropRate, iceEndPoint);
                MeltIceCubes();
            }
            else
            {
                CollapseMercuryLevels(0.00002f, iceEndPoint);
            }
        }
    }

    private void SodiumHydroxideReaction()
    {
        if (sodiumPelletes.activeSelf == true) 
        {
            if (stirTime > 0.4f)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(1.3f,1.5f));
            }
        }
    }

    //melt ice cubes gradually
    void MeltIceCubes()
    {
        if (iceCube.activeSelf)
        {
            for (int i = 0; i < iceCubes.Length; i++)
            {
                iceCubes[i].LeanScaleX(0f, 1f);
                iceCubes[i].LeanScaleY(0f, 1f);
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
