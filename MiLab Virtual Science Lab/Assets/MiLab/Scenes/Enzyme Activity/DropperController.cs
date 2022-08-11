using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperController : MonoBehaviour
{
    public GameObject[] dropArea;

    private float startPressTime, stopPressTime;

    bool hasCollided;

    bool isAboveContainer;

    float dragTime;
    
    GameObject selectedDropArea;

    private void Start()
    {
        startPressTime = 0.0f;
        stopPressTime = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject a in dropArea)
        {
            if(collision.gameObject.name == a.name)
            {
                hasCollided = true;
                selectedDropArea = collision.gameObject;
            } 
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject a in dropArea)
        {
            if (collision.gameObject.name == a.name)
            {
                hasCollided = false;
                selectedDropArea = null;
            }
        }
        
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseDrag()
    {
        if(isAboveContainer)
        {
            dragTime = Time.time * 1.0f;
            Debug.Log("drag: " + dragTime);
        }
        
        if(dragTime>6.0f)
        {
            dragTime = 0.0f;
            Debug.Log("Can be released");
        }
    }
    private void OnMouseUp()
    {
        dragTime = 0.0f;

        if(hasCollided)
        {
            gameObject.transform.position = new Vector3(selectedDropArea.transform.position.x, selectedDropArea.transform.position.y, 0);
            gameObject.GetComponent<SpriteDrag>().canDrag = false;
            isAboveContainer = true;
            
        }
       
    }

    private void Update()
    {
        
        if(hasCollided)
        {
            gameObject.transform.LeanRotateZ(-10.0f, 0.5f);   
        }

        else
        {
            gameObject.transform.LeanRotateZ(0.0f, 0.5f);
        }

       
    }
}
