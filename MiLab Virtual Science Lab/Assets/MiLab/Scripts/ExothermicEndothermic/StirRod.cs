using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StirRod : MonoBehaviour,IDragHandler, IDropHandler
{

    public bool shouldSnapBack; //set true in the inspector if the object is supposed to snap back to it's original position
    private Vector3 initialposition;
    public float minPosX, maxPosX; //set max and min distance that the object can be dragged in the inspector

    private void Start()
    {
        initialposition = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventdata)
    {   
        transform.position = new Vector3(Input.mousePosition.x, initialposition.y);
     
        //transform.localPosition = new Vector3(Input.mousePosition.x, initialposition.y, initialposition.z);
        
        if(transform.localPosition.x < minPosX)
        {
           transform.LeanMoveLocalX(-2f, 0.5f);
        }
        else if(transform.localPosition.x > maxPosX)
        {
            transform.LeanMoveLocalX(2f, 0.5f);
        }
    }

    public void OnDrop(PointerEventData eventdata)
    {
        if (shouldSnapBack)
        {
            transform.localPosition = initialposition;
        }
    }

}
