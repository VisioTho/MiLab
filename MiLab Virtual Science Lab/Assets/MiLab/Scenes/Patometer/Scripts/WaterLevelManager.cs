using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : ThermometerBehaviour
{
    public static bool patometerIsConnected;
    public static bool isReset;
    
   public static void AdjustWaterLevel(PlantManager plantData)
    {
        
        TranspirationManager transpirationManager = new TranspirationManager(plantData);
        patometerIsConnected = transpirationManager.isConnectedToPatometer;
    }

   
    private void Update()
    {
        Debug.Log("is reset is " + isReset);
        if(patometerIsConnected)
        {
            CollapseMercuryLevels(0.002f, 0.0f);
        }
        if(isReset)
        {
            RiseMercuryLevels(0.02f, 3.0f);
        }
   
    }

    public void ResetWaterLevel()
    {
        isReset = true;
    }
}
