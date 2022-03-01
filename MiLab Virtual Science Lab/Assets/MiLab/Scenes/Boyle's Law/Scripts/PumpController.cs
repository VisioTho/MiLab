using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    private float posAtTimeOfTouch;
    public static float offsetAfterRelease;
    public static bool isDragged;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Offset " +offsetAfterRelease +" Pointoftouch " +posAtTimeOfTouch +"current pos: " +transform.position.y);
        offsetAfterRelease = posAtTimeOfTouch - transform.position.y;
       
    }

    void OnMouseDown()
    {
        //offsetAfterRelease = 0f;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(initialPos.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        posAtTimeOfTouch = transform.position.y;
    }
    void OnMouseDrag()
    {
        //Debug.Log(transform.position.y);
        Vector3 curScreenPoint = new Vector3(initialPos.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); //+ offset;
        transform.position = curPosition;
        RestrictPosition();
        isDragged = true;
       
    }

    private void RestrictPosition()
    {
        if (transform.position.x < initialPos.x)
        {
            transform.position = new Vector2(-4.52f, transform.position.y);
        }
        else if (transform.localPosition.x > initialPos.x)
        {
            transform.position = new Vector2(-4.52f, transform.position.y);
        }

        if (transform.position.y > initialPos.y)
        {
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
        else if (transform.localPosition.y < 1.2f)
        {
            transform.position = new Vector2(-4.52f, 1.2f);
        }
    }

    private void OnMouseUp()
    {
        
        //offsetAfterRelease = posAtTimeOfTouch - posAtTimeOfRelease;
        isDragged = false;
        offsetAfterRelease = 0f;
        if (posAtTimeOfTouch >= 1.2f || posAtTimeOfTouch<=1.3f)
        {
            transform.position = new Vector2(transform.position.x, 1.4f);
        }
    }
}
