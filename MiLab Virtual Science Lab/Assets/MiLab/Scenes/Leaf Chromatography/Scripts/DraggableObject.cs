using System;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool allowX = true; // Allow movement on X-axis
    public bool allowY = true; // Allow movement on Y-axis

    public float minX = float.NegativeInfinity; // Minimum X limit
    public float maxX = float.PositiveInfinity; // Maximum X limit
    public float minY = float.NegativeInfinity; // Minimum Y limit
    public float maxY = float.PositiveInfinity; // Maximum Y limit

    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        // Apply movement restrictions
        float clampedX = allowX ? Mathf.Clamp(curPosition.x, minX, maxX) : transform.position.x;
        float clampedY = allowY ? Mathf.Clamp(curPosition.y, minY, maxY) : transform.position.y;

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        Debug.Log(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("2");
    }
}
