using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : ThermometerBehaviour
{
    public static bool patometerIsConnected;
    public static bool isReset;
    public static bool isBlowing;
    public static bool isCoolingRoom;
    public GameObject tap;
    private Vector2 tapInitialPosition;
    ParticleSystem bubble;
    float originalSpeed;
    public GasTapController tapController;

    private void Start()
    {
        bubble = GetComponent<ParticleSystem>();
        originalSpeed = bubble.main.simulationSpeed;
        tapInitialPosition = tap.transform.position;
    }
    public static void AdjustWaterLevel(PlantManager plantData)
    {
        
        TranspirationManager transpirationManager = new TranspirationManager(plantData);
        patometerIsConnected = transpirationManager.isConnectedToPatometer;
    }

   
    public static void BlowWind(WindController wind)
    {
        TranspirationManager transpirationManager = new TranspirationManager(wind);
        isBlowing = transpirationManager.isBlowingWind;
    }

    public static void CoolRoom(AirConController airCon)
    {
        TranspirationManager transpiration = new TranspirationManager(airCon);
        isCoolingRoom = transpiration.isCooling;
    }


    private void Update()
    {
        if (tap.transform.position.x < tapInitialPosition.x) 
        {
            isReset = true;
        }
        else
        {
            isReset = false;
        }


        ManageAirBubble();

      

        void SetParticleSpeed(float speed)
        {
            var bubbleMain = bubble.main;
            bubbleMain.simulationSpeed = speed;
            Debug.Log("ili apa: " + bubble.time);
        }

        void ManageAirBubble()
        {
            if(bubble.time>=4.9f && !isReset)
            {
                if (bubble.isPlaying)
                    bubble.Pause();
            }

            if (patometerIsConnected && bubble.time<4.9f)
            {
                bubble.Play();

                if (isBlowing && !isCoolingRoom)
                {

                    SetParticleSpeed(0.3f);

                }
                
                else if(isCoolingRoom && !isBlowing)
                {
                    SetParticleSpeed(0.05f);
                }

                else if(isCoolingRoom && isBlowing)
                {
                    SetParticleSpeed(0.2f);
                }

                else if(!isCoolingRoom && !isBlowing)
                {
                    SetParticleSpeed(originalSpeed);
                }
                
            }

            else if (!patometerIsConnected)
            {
                if (bubble.isPlaying)
                {
                    bubble.Pause();
                }
            }

            if (isReset)
            {
                bubble.Clear();
                bubble.time = 0.0f;
            }
        }
    }

    public void ResetWaterLevel()
    {
        isReset = true;
    }
}
