using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        Debug.Log("tapped");
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Debug.Log("dragged");
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}
