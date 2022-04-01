using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{
    public static bool lMassIsReleased = true;
    public static bool RMassIsReleased = true;
    public static GameObject massHungOnLeft;
    public static GameObject massHungOnRight;
    // Start is called before the first frame update
    void Start()
    {
        RMassIsReleased = true;
        lMassIsReleased = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
