using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StirRod : MonoBehaviour, IDragHandler, IDropHandler
{
    public bool shouldSnapBack;
    private Vector3 initialposition;
    public float minPosX, maxPosX;

    private void Start()
    {
        initialposition = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventdata)
    {
        if(transform.position.x >= minPosX && transform.position.x <= maxPosX)
        {
            transform.position = new Vector3(Input.mousePosition.x, initialposition.y, initialposition.z);
        }
        else if(transform.position.x < minPosX)
        {
            transform.LeanMoveLocalX(-2f, 0.5f);
        }
        else if(transform.position.x > maxPosX)
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
