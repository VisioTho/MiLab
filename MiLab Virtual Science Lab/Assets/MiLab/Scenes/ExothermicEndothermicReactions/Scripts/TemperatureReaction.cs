using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using UnityEngine.UI;

public partial class TemperatureReaction : ThermometerBehaviour//, IMercury
{
    public ParticleSystem powderParticles;
    public ParticleSystem exothermicTrace, endothermicTrace;
    public static float emissionTime;
    public static float stirTime;
    public float temperatureDropRate;
    public TMP_Text tempReading;
    public GameObject[] iceCubes;
    public static GameObject sodiumPelletes;
    public GameObject[] pellets;
    public GameObject iceCube;
    //public GameObject water;
    float iceEndPoint;
    Vector3 initialPosition;
    Vector3 initialScale;

    public Button removeSoluteButton;
    public TMP_Text chemicalDisplay, chemicalProduct1, chemicalProduct2;
 
    
    Vector3 initialTemperatureLevels;
    private float initialTemperature;

    public static GameObject[] pelletsToMelt;
    
    
    public class Substances
    {
        public Vector2 thermometerLevels;
        public float changeInTemperature;
    }

    Substances potassiumNitrate = new Substances();
    Substances ice = new Substances();
    Substances sodiumHydroxide = new Substances();
    private void Start()
    {
        counter = 0;
        stirTime = 0f;
        ice.changeInTemperature = Random.Range(0.4f, 0.2f);
        sodiumHydroxide.changeInTemperature = Random.Range(1.3f, 1.55f);
        transform.localScale = new Vector2(transform.localScale.x, Random.Range(2.0f, 2.2f));
        initialTemperatureLevels = transform.localScale;
        initialTemperature = CalculateTemperature();

        if(exothermicTrace.isPlaying)
        {
            exothermicTrace.Stop();
        }

        if(endothermicTrace.isPlaying)
        {
            endothermicTrace.Stop();
        }

        initialPosition = pellets[0].transform.position;
        initialScale = pellets[0].transform.localScale;
        
    }

    private void resetStirTime()
    {
        stirTime = 0f;
    }

    private void ResetTemp()
    {
        //transform.localScale = new Vector2(transform.localScale.x, 5f);
        transform.localScale = initialTemperatureLevels;
    }
    public void ResetTemperature()
    {
        chemicalDisplay.text = "";
        chemicalProduct1.text = "";
        chemicalProduct2.text = "";
        emissionTime = 0f;
        resetStirTime();
        removeSoluteButton.interactable = false;
        ResetTemp();
        iceEndPoint = Random.Range(0.4f, 0.2f);
        ResetSizeAndPosition(iceCubes);
        for (int i = 0; i < pellets.Length; i++)
        {
            pellets[i].transform.position =  initialPosition;
            pellets[i].transform.localScale = initialScale;
            pellets[i].GetComponent<Rigidbody2D>().simulated = true;
            pellets[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            pellets[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        pellets[0].transform.position = initialPosition;
        counter = 0;

        //water.transform.localScale = new Vector3(1f, 1f, 1f);
        
    }


    private void ResetSizeAndPosition(GameObject[] objects)
    {
        foreach (GameObject i in objects)
        {
            i.transform.LeanScaleX(0.02776602f, 0.5f);
            i.transform.LeanScaleY(0.03039036f, 0.5f);
            
            //i.transform.LeanScaleX(1f, 0.5f);
            i.transform.LeanMoveLocalY(0.02f, 0.5f);
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
        ToggleEnergyTrace();

    }

    // Play or stop the energy trace particle based on temperature readings
    private void ToggleEnergyTrace()
    {
        var currTemp = float.Parse(CalculateTemperature().ToString("F0"));
        var initialTemp = float.Parse(initialTemperature.ToString("f0"));
        if (currTemp < initialTemp)
        {
            if (!endothermicTrace.isPlaying)
                endothermicTrace.Play();
        }
        else if (currTemp > initialTemp)
        {
            if (!exothermicTrace.isPlaying)
                exothermicTrace.Play();
        }
        else
        {
            exothermicTrace.Stop();
            endothermicTrace.Stop();
        }

        Debug.Log("initial temp: " + initialTemp + " current temp " + currTemp);
        
    }

    public void PlayEnergyTrace(ParticleSystem particleSystem)
    {
        if (!particleSystem.isPlaying)
            particleSystem.Play();

        if (particleSystem.isPlaying)
            particleSystem.Stop();
    }
    private void GetThermometerReading()
    {
        tempReading.text = CalculateTemperature().ToString("f0");
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
