using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelController : ThermometerBehaviour, IMercury
{
    public GameObject jetStream;
    private void Update()
    {
        if(jetStream.activeSelf)
        {
            RiseMercuryLevels(0.002f, 3.5f);
        }
    }
}
