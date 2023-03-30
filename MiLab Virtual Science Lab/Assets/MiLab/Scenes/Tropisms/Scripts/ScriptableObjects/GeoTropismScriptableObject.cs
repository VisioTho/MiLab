using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="Bone Kinematic",menuName="Tropisms Items/My Items/Bone Kinematic")]
public class GeoTropismScriptableObject : ScriptableObject
{
    public bool needsKinematic;
    public bool upperBoneTracking;
    public bool lowerBoneTracking;
}
