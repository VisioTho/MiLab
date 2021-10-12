using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMercury<T>
{
    public void RiseMercuryLevels(float speed);
    public void CollapseMercuryLevels(float speed);
}