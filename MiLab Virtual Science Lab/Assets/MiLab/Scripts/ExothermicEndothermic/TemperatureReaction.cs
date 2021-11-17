using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using UnityEngine.UI;

public class TemperatureReaction : ThermometerBehaviour//, IMercury
{
    public ParticleSystem powderParticles;
    private float emissionTime;
    public static float stirTime;
    public float temperatureDropRate;
    public TMP_Text tempReading;
    public GameObject[] iceCubes;
    public GameObject sodiumPelletes;
    public GameObject[] pellets;
    public GameObject iceCube;
    //public GameObject water;
    float iceEndPoint;
    Vector3 initialPosition;
    Vector3 initialScale;

    public Button removeSoluteButton;
    public TMP_Text chemicalDisplay;
 
    public ParticleSystem EnergyTraceEndothermic, energyTraceExothermic;
    Vector2 temperatureLevels;
    
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
        ice.changeInTemperature = Random.Range(0.4f, 0.2f);
        sodiumHydroxide.changeInTemperature = Random.Range(1.3f, 1.55f);
        transform.localScale = new Vector2(1f, Random.Range(0.8f, 1.0f));

        initialPosition = pellets[0].transform.position;
        initialScale = pellets[0].transform.localScale;
        
    }

    //keep track of how long the theremometer rod is being moved in 'stiring' fashion
    public void CountStirTime()
    {
        if (emissionTime > 1f || iceCube.activeSelf || sodiumPelletes.activeSelf)
            stirTime += Time.deltaTime * 1f;
    }
    public void resetStirTime()
    {
        stirTime = 0f;
    }
    public void ResetTemperature()
    {
        chemicalDisplay.text = "Water";
        emissionTime = 0f;
        resetStirTime();
        removeSoluteButton.interactable = false;
        transform.localScale = new Vector2(transform.localScale.x, 1f);
        transform.localScale = new Vector2(1f, Random.Range(0.9f, 1.0f));
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
        SodiumHydroxideReaction.counter = 0;

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
    float lowTempRise;
    float lowerMidTempRise;
    float higherMidTempRise;
    float highTempRise;
    void Update()
    {
        CountEmissionTime();
        PottasiumNitrateReaction();
        GetThermometerReading();
        IceReaction();
        //SodiumHydroxideReaction();

        var particles = energyTraceExothermic.main;
        //Debug.Log("stir time be" +stirTime);
        if (stirTime > 1.2f)
        {
            if (SodiumHydroxideReaction.counter == 1)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(1.1f, 1.15f));
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Sodium Hydroxide";
                //MeltSodiumHydroxide(0.00002f);
                energyTraceExothermic.Emit(5);
                //stirTime = 0f;
            }
            else if (SodiumHydroxideReaction.counter == 2)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(1.16f, 1.2f));
                //MeltSodiumHydroxide(0.00002f);
                energyTraceExothermic.Emit(5);
                Debug.Log("Should be 2");
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Sodium Hydroxide";
            }
            else if(SodiumHydroxideReaction.counter == 3)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(1.21f, 1.24f));
                //MeltSodiumHydroxide(0.00002f);
                energyTraceExothermic.Emit(5);
                Debug.Log("Should be 2");
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Sodium Hydroxide";
            }
            else if (SodiumHydroxideReaction.counter >= 4)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(1.46f, 1.65f));
                //MeltSodiumHydroxide(0.00002f);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Sodium Hydroxide";
                energyTraceExothermic.Emit(5);
                Debug.Log("Should be 3");
            }

        }
        else
            particles.playOnAwake = false;
    
    }

    private void GetThermometerReading()
    {
        tempReading.text = CalculateTemperature().ToString("f1");
    }

    //how temperature changes when potassium reacts with the water
    private void PottasiumNitrateReaction()
    {
        if (stirTime > 1.2f)
        {
            
            
            if (emissionTime > 1f && emissionTime < 4f)
            {
                var tempChange = Random.Range(0.9f, 0.8f);
                potassiumNitrate.changeInTemperature = tempChange;
                EnergyTraceEndothermic.Emit(5);
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Pottasium Nitrate";
            }

            else if (emissionTime > 4f && emissionTime < 8f)
            {
                var tempChange = Random.Range(0.6f, 0.7f);
                potassiumNitrate.changeInTemperature = tempChange;
                EnergyTraceEndothermic.Emit(5);
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Pottasium Nitrate";
            }
            else if(emissionTime > 8f)
            {
                var tempChange = Random.Range(0.3f, 0.5f);
                potassiumNitrate.changeInTemperature = tempChange;
                EnergyTraceEndothermic.Emit(5);
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Pottasium Nitrate";
            }
        }
        
    }

    //how temperature changes when ice reacts with liquid water
    private void IceReaction()
    {
        if(iceCube.activeSelf==true) // if at least the first ice cube is active
        {     
            if(stirTime>1.2f)
            {
                CollapseMercuryLevels(temperatureDropRate, ice.changeInTemperature);
                EnergyTraceEndothermic.Emit(5);
                MeltIceCubes(0.00002f);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Ice";
            }
            else
            {
                CollapseMercuryLevels(0.00002f, ice.changeInTemperature);
                MeltIceCubes(0.0000002f);
            }  
        }
    }

   /* private void SodiumHydroxideReaction()
    {
        if (sodiumPelletes.activeSelf == true) 
        {   
            var particles = energyTraceExothermic.main;
            if (stirTime > 0.4f && pellets[0].activeSelf)
            {
                if(pellets[0].activeSelf)
                {
                    RiseMercuryLevels(temperatureDropRate, Random.Range(1.3f, 1.35f));
                    MeltSodiumHydroxide(0.00002f);
                    energyTraceExothermic.Emit(5);
                }
                else if(pellets[1].activeSelf)
                {
                    RiseMercuryLevels(temperatureDropRate, Random.Range(1.36f, 1.45f));
                    MeltSodiumHydroxide(0.00002f);
                    energyTraceExothermic.Emit(5);
                }
                else if(pellets[2])
                {
                    RiseMercuryLevels(temperatureDropRate, Random.Range(1.46f, 1.65f));
                    MeltSodiumHydroxide(0.00002f);
                    energyTraceExothermic.Emit(5);
                }
               
            }
            else
                particles.playOnAwake = false;
           
        }
    }
   */

    //melt ice cubes gradually
    int stopper = 0; // prevents update from being called more than once on this function
    public void MeltIceCubes(float meltSpeed)
    {
        if (iceCube.activeSelf && stopper==0)
        {
            for (int i = 0; i < iceCubes.Length; i++)
            {
                Vector2 tempScale = iceCubes[i].transform.localScale;
                var V = meltSpeed;
                if (tempScale.y > 0.01 && tempScale.x>0.01)
                {
                    tempScale.y -= V; 
                    tempScale.x -= V;
                    iceCubes[i].transform.localScale = tempScale;
                }
            }
            
        } 
    }

    void MeltSodiumHydroxide(float meltSpeed)
    {
        if (pellets[0].activeSelf && stopper == 0)
        {
            for (int i = 0; i < pellets.Length; i++)
            {
                if(pellets[i].activeSelf)
                {
                    Vector2 tempScale = pellets[i].transform.localScale;
                    var V = meltSpeed;
                    if (tempScale.y > 0.01 && tempScale.x > 0.01)
                    {
                        tempScale.y -= V;
                        tempScale.x -= V;
                    
                        pellets[i].transform.localScale = tempScale;
                    }
                }  
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
