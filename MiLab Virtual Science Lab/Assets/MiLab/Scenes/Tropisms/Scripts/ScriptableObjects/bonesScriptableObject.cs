using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

///<summary>
///Positions 1 for Left, 2 for Center, 3 for Right
/// this scriptable object is in charge of determining the direction
/// that have been set for the bones to move towards.
/// while the bones monobehavior(TreeController) is handling the math
/// this object will change the value for left, center and right variables
/// these a change in these values will be registered to a unity event
/// other components will subcribe to this event and react in their own way
///</summary>

[CreateAssetMenu(fileName="New Bone Object",menuName="Tropisms Items/My Items/Bone")]
public class bonesScriptableObject : ScriptableObject
{
   
    private bool moveLeft;
    private bool moveCenter;
    private bool moveRight;
    public int direction;

    //Event to subscribe for notifications of change
    [System.NonSerialized]
    public UnityEvent<int> moveChangeEvent;

    private void OnEnable(){
        moveCenter = true;
        direction = 2;
        if(moveChangeEvent == null)
            moveChangeEvent = new UnityEvent<int>();
    }

    public void moveToLeft()
    {

        moveLeft = true;
        moveRight = false;
        moveCenter = false;
        direction = 1;
        moveChangeEvent.Invoke(direction);

    }

    public void moveToCenter()
    {
    
        moveCenter = true;
        moveRight = false;
        moveLeft = false;
        direction = 2;
        moveChangeEvent.Invoke(direction);

    }

    public void moveToRight()
    {

        moveRight = true;
        moveLeft = false;
        moveCenter = false;
        direction = 3;
        moveChangeEvent.Invoke(direction);
    }
}
