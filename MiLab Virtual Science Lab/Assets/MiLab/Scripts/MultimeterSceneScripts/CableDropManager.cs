using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CableDropManager : MonoBehaviour, IDropHandler
{
    public static bool isDropped = false;
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("dropped");
        if (data.pointerDrag != null)
        {
            if (data.pointerDrag.name == "red_cable" && this.gameObject.name == "current_cable_drop_area") ;
            {
                isDropped = true;
                GameObject D = data.pointerDrag;
                D.transform.position = this.gameObject.transform.position;
            }
        }
    }
}
