using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New Center Light Object",menuName="Tropisms Items/My Items/Light/Center")]
public class CenterLightObject : LightPositionObject
{
    public void Awake()
    {
        position = LightPosition.Center;
    }
}