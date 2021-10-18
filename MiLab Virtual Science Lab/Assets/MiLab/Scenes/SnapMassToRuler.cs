using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapMassToRuler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedItem = eventData.pointerDrag;
        HingeJoint2D draggedItemHinge = draggedItem.GetComponent<HingeJoint2D>();
        if (draggedItemHinge!=null)
        {
            draggedItemHinge.connectedBody = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
