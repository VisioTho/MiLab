using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New Left Light Object",menuName="Tropisms Items/My Items/Light/Left")]
public class LeftLightObject : LightPositionObject
{
    public void Awake()
    {
        position = LightPosition.Left;
    }
}
