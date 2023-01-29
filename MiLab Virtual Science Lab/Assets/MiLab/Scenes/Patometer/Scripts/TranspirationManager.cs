using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranspirationManager : MonoBehaviour
{
    public bool isConnectedToPatometer;
    
    public TranspirationManager(PlantManager plant)
    {
        isConnectedToPatometer = plant.isConnectedToTube;
       
    }

}
