using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConSwitch : MonoBehaviour
{
    public DialSwicth dialSwicth;
    public bool isCoolingRoom;

    private void Update()
    {
        if(dialSwicth.isRotated)
        {
            isCoolingRoom = true;
        }
        else
        {
            isCoolingRoom = false;
        }
    }
}
   
   

