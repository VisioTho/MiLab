using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropperManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        FlintDropHandler.isFlint = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
    }
}
