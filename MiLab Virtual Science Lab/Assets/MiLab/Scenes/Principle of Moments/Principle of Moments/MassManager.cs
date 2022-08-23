using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MassManager 
{
    public static bool lMassIsReleased = true;
    public static bool RMassIsReleased = true;
    public static bool mouseUp;
    public static bool canBalance = true;
    public static Collider2D[] lConnectionPoints, rConnectionPoints;
    public static string hangPointR, hangPointL;

    public static float lPosOnAttachment, rPosOnAttachment;

    public static GameObject massHungOnLeft;
    public static GameObject massHungOnRight;
    public static GameObject ruler;
    public static float rotationByLeftMass, rotationByRightMass;
    public static bool hasHadBothMassesAttached = false;
    
    public static void ToggleHangPoints(Collider2D[] colliders, bool v)
    {
        foreach(Collider2D col in colliders)
        {
            col.enabled = v;
        }
    }
    

    
}
