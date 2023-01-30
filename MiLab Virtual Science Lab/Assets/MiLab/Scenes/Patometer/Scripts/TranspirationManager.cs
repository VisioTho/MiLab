using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranspirationManager : MonoBehaviour
{
    public bool isConnectedToPatometer;
    public bool isBlowingWind;
    public bool isCooling;
    
    public TranspirationManager(PlantManager plant)
    {
        isConnectedToPatometer = plant.isConnectedToTube;
       
    }

    public TranspirationManager(WindController wind)
    {
        isBlowingWind = wind.isBlowingWind;
    }

    public TranspirationManager(AirConController airCon)
    {
        isCooling = airCon.isCooling;
    }

}
