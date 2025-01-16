using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRigidbody2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDragging;
    private Vector3 offset;
    [SerializeField] private float minPosX, maxPosX, minPosY, maxPosY;
    [SerializeField] private bool limitMovement;

    void Start()
    {
        isDragging = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;

            if(limitMovement)
            {
                if(newPosition.y < maxPosY && newPosition.y > minPosY)
                {
                    if (newPosition.x < maxPosX && newPosition.x > minPosX)
                    {
                        rb.MovePosition(newPosition);
                    }
                }
            }
            else
            {
                rb.MovePosition(newPosition);
            }
            
            
            
        }
    }
}

