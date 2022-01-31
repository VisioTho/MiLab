using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTapController : MonoBehaviour
{
    
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;


    private void Start()
    {
        initialPos = transform.position;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, initialPos.y, -Camera.main.transform.position.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, initialPos.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); //+ offset;
        transform.position = curPosition;
        RestrictPosition();
        
    }

    private void RestrictPosition()
    {
       if (transform.position.y < initialPos.y)
        {
            transform.position = new Vector2(transform.position.x, initialPos.y);
        }
        else if (transform.position.y > initialPos.y)
        {
            transform.position = new Vector2(transform.position.x, initialPos.y);
        }

       if(transform.position.x < 1)
        {
            transform.position = new Vector2(1f, initialPos.y);
        }
       else if(transform.position.x > initialPos.x)
        {
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
     
    }

    private void Update()
    {
        
    }
    private void OnMouseUp()
    {
       
    }
}
