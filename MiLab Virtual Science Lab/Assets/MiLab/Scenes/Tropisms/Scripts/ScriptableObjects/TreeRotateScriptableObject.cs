using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

///<summary>
/// This is an event scriptable object that will keep track of the mouse event on a given object
/// This scriptable object will change the value of mouseOn variable right after a mouse event
/// the mouseOn value 0 and 1 are for when the mouse has been clicked and pressed
/// the mouseOn value 3 is for when a mouse has been released
/// this has been made into an event to be kept during run time to avoid repeating the mouse events 
/// several times in different scripts which are searching for the same event
/// instead this event will just be subscribed to and so other components will just have to interact 
/// with the scripatble object values and won't need to call the mouse event again
///</summary>
[CreateAssetMenu(fileName="Object Press Event",menuName="Tropisms Items/Events/Press")]

public class TreeRotateScriptableObject : ScriptableObject
{ 
    
    public int mouseOn;
    public bool resetButton;

  [System.NonSerialized]
    public UnityEvent<int> treeClickedEvent;
    public UnityEvent<bool> treeResetEvent;

    private void OnEnable()
    {
        mouseOn = 0;
        if(treeClickedEvent == null)
            treeClickedEvent = new UnityEvent<int>();
    }

    public void HandleMouseEvent()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            mouseOn = 0;
            treeClickedEvent.Invoke(mouseOn);
            Debug.Log("Mouse Clicked");

        }else if (Input.GetMouseButton(0))
        {
            mouseOn = 1;
            resetButton = false;
            treeClickedEvent.Invoke(mouseOn);
            Debug.Log("Mouse Lifted");
        }else
        {
            mouseOn = 3;
            treeClickedEvent.Invoke(mouseOn);
            Debug.Log("Mouse Off");
        }
        
        
    
        
    }

    public void resetButtonGeo()
    {
        resetButton = true;
        treeResetEvent.Invoke(resetButton);
    }

    
}
