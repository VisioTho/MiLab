using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///<summary>
/// Subscribes to the bones scriptable object event for the direction change
/// keep a variable of the type LightPositionObject, a scriptable object for Identifying the 
/// type of light that this script is attached to[Left, Center, Right]
/// makes decisions of turning the light on using the direction variable
/// if direction is 1, only the light with ID 1(Left) is left on
/// if direction is 2, only the light with ID 2(center) is left on
/// if direction is 3, only the light with ID 3(right) is left on
///</summary>
public class LightController : MonoBehaviour
{
    [SerializeField]
    public LightPositionObject lightPositionObject;

    public bonesScriptableObject bonescriptableobject;
    private Light light;


    void Start()
    {
        light = this.GetComponent<Light>();
        
        if(lightPositionObject.position != LightPosition.Center)
        {
            light.enabled = true;
        }else
        {
            light.enabled = false;
        }
    }

    private void OnEnable()
    {
        bonescriptableobject.moveChangeEvent.AddListener(lightSwitch);
    }


    void Update()
    {
        lightSwitch(bonescriptableobject.direction);
    }

    
    public void lightSwitch(int direction)
        {
            if(direction == 1 && lightPositionObject.position != LightPosition.Left)
            {
                light.enabled = false;
            }else if(direction == 2 && lightPositionObject.position != LightPosition.Center)
            {
                light.enabled = false;
            }else if(direction == 3 && lightPositionObject.position != LightPosition.Right)
            {
                light.enabled = false;
            }else
            {
                light.enabled = true;
            }
            
        }
}
