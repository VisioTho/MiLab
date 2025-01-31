using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Right Light Object",menuName="Tropisms Items/My Items/Light/Right")]
public class RightLightObject : LightPositionObject
{
    public void Awake()
    {
        position = LightPosition.Right;
    }
}
