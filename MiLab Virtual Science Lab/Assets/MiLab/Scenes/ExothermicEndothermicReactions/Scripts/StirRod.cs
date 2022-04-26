using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StirRod : MonoBehaviour
{

    public bool shouldSnapBack; //set true in the inspector if the object is supposed to snap back to it's original position
    private Vector3 initialposition;
    public float minPosX, maxPosX; //set max and min distance that the object can be dragged in the inspector

    private void Start()
    {
        initialposition = gameObject.transform.position;
    }

    /*public void OnDrag(PointerEventData eventdata)
    {   
        transform.position = new Vector3(Input.mousePosition.x, initialposition.y);
     
        //transform.localPosition = new Vector3(Input.mousePosition.x, initialposition.y, initialposition.z);
        
        if(transform.localPosition.x < minPosX)
        {
            //transform.LeanMoveLocalX(-0.2f, 0.5f);
            transform.localPosition = new Vector2(minPosX, transform.localPosition.y);
        }
        else if(transform.localPosition.x > maxPosX)
        {
            transform.localPosition = new Vector2(maxPosX, transform.localPosition.y);
        }
    }*/
    Vector3 offset;
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {
        //TemperatureReaction.CountStirTime();
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, transform.position.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); //+ offset;
        transform.position = curPosition;
        if (transform.localPosition.x < minPosX)
        {
            //transform.LeanMoveLocalX(-0.2f, 0.5f);
            transform.localPosition = new Vector2(minPosX, transform.localPosition.y);
        }
        else if (transform.localPosition.x > maxPosX)
        {
            transform.localPosition = new Vector2(maxPosX, transform.localPosition.y);
        }

        //TemperatureReaction.CountStirTime();
    }

    private void Update()
    {
        if(transform.position.y!=initialposition.y)
        {
            transform.position = new Vector3(transform.position.x, initialposition.y, transform.position.z);
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
