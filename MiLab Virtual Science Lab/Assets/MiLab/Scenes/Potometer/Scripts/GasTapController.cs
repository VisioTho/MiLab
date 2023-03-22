using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GasTapController : MonoBehaviour
{
    public float tapEndPoint;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 initialPos;
    public LineRenderer lineRenderer;
    private Color startColor;
    private Color endColor;


    private void Start()
    {
        initialPos = transform.position;
        startColor = new Color(1f, 0.0f, 0.0f);
        endColor = new Color(1f, 0.1f, 0.1f);
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

       if(transform.position.x < tapEndPoint)
        {
            transform.position = new Vector2(tapEndPoint, initialPos.y);
        }
       else if(transform.position.x > initialPos.x)
        {
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
     
    }

    private void Update()
    {
        if (transform.position.x <= tapEndPoint)
        {
            //transform.position = new Vector2(tapEndPoint, initialPos.y);
            lineRenderer.startColor = startColor;
            lineRenderer.endColor = endColor;
        }
        else
        {
            lineRenderer.startColor = new Color(0.0f, 0.0f, 0.0f); 
            lineRenderer.endColor = new Color(0.0f, 0.0f, 0.0f);
        }
    }

}
