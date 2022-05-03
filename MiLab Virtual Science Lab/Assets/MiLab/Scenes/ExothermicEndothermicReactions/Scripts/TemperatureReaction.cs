using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using UnityEngine.UI;

public partial class TemperatureReaction : ThermometerBehaviour//, IMercury
{
    public ParticleSystem powderParticles;
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
        ice.changeInTemperature = Random.Range(0.4f, 0.2f);
        sodiumHydroxide.changeInTemperature = Random.Range(1.3f, 1.55f);
        transform.localScale = new Vector2(transform.localScale.x, Random.Range(2.0f, 2.2f));
        initialTemperatureLevels = transform.localScale;

        initialPosition = pellets[0].transform.position;
        initialScale = pellets[0].transform.localScale;
        
    }

    //keep track of how long the theremometer rod is being moved in 'stiring' fashion
   /*private void CountStirTime()
    {
        stirTime += Time.deltaTime * 1f;
        if (emissionTime > 1f || iceCube.activeSelf || sodiumPelletes.activeSelf)
        {
            if(StirRod.isStirring)
            {
                stirTime += Time.deltaTime * 1f;
            }

        }
            
    }*/
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
        Debug.Log("Has been reset" +stirTime);
        chemicalDisplay.text = "";
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
        //CountStirTime();
        //SodiumHydroxideReaction();

        Debug.Log("initial temperature is: " + initialTemperatureLevels.y + " Current temperature: " + transform.localScale.y);


        
        //Debug.Log("stir time be" + stirTime);
        SodiumHydroxideReaction();

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
