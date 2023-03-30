using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightPosition
{
    Left,
    Center,
    Right
}

public abstract class LightPositionObject : ScriptableObject
{
   public LightPosition position;

}
