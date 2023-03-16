using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranspirationManager : MonoBehaviour
{
    public bool isConnectedToPatometer;
    public bool isBlowingWind;
    public bool isCooling;
    
    public TranspirationManager(BeakerController beaker)
    {
        isConnectedToPatometer = beaker.isConnectedToTube;
       
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
