using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PipetteDropHandler : MonoBehaviour, IDropHandler
{
    public static bool isDropped = false;
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("dropped");
        if (data.pointerDrag != null)
        {
            if (data.pointerDrag.name == "pipette")
            {
                isDropped = true;
            }
        }
    }
}
