using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggables : MonoBehaviour, IDragHandler, IDropHandler
{
    public void OnDrag(PointerEventData eventdata)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventdata)
    {

    }

}
