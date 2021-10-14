using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMercury
{
    public void RiseMercuryLevels(float speed, float riseBy);
    public void CollapseMercuryLevels(float speed, float dropBy);
}