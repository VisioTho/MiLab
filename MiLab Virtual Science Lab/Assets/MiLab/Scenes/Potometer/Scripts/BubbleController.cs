using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public static bool patometerIsConnected;
    public static bool isReset;
    public static bool isBlowing;
    public static bool isCoolingRoom;
    public float moveSpeed; // Speed at which the bubble moves along the x-axis
    public bool canMove = false; // Boolean to control movement
    public GameObject tap;
    private Vector2 tapInitialPosition;
    private Vector2 initialPos;
    
    float originalSpeed;
    public GasTapController tapController;

    private void Start()
    {
        patometerIsConnected = false;
        tapInitialPosition = tap.transform.position;
        initialPos = gameObject.transform.position;
    }
    public static void InitiateBubbleMovement(BeakerController beakerData)
    {
        
        TranspirationManager transpirationManager = new TranspirationManager(beakerData);
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

    const float MAXBUBBLETIME = 7.0f;
    private void Update()
    {
        OpenTap();

        ManageAirBubble();

        

        void ManageAirBubble()
        {
            Debug.Log("patometer" + patometerIsConnected);

            if (patometerIsConnected )
            {
                
                canMove = true;
                GetComponent<SpriteRenderer>().enabled = true;

                if(transform.position.x<= -1.04f && !isReset)
                {
                    
                    if (isBlowing && !isCoolingRoom)
                    {
                        moveSpeed = 0.09f;
                    }

                    else if (isCoolingRoom && !isBlowing)
                    {
                        moveSpeed = 0.01f;
                    }

                    else if (isCoolingRoom && isBlowing)
                    {
                        moveSpeed = 0.01f;
                    }

                    else if (!isCoolingRoom && !isBlowing)
                    {
                        moveSpeed = 0.08f;
                    } 

                    if (canMove)
                    {
                        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f); // Move the sprite along the x-axis continuously
                    }
                }

               

            }

            else if (!patometerIsConnected)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                canMove = false;
            }

            if (isReset)
            {
                if(transform.position.x >= initialPos.x)
                {
                    moveSpeed = -0.1f;
                    transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f); // Move the sprite along the x-axis continuously
                }
                
            }
        }

        void OpenTap()
        {
            if (tap.transform.position.x < tapInitialPosition.x)
            {
                isReset = true;
            }
            else
            {
                isReset = false;
            }
        }
    }

    public void ResetWaterLevel()
    {
        isReset = true;
    }
}
