using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PumpController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    public static bool isDragged;
    public static bool isPumped;
    private bool canPump;

    private void Start()
    {
        initialPos = transform.position;
        isPumped = false;
        canPump = false;
    }

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Vector2 posOnTouch = transform.position;
        transform.position = posOnTouch; ;
    }
    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);// + offset;
        transform.position = curPosition;

       
        isDragged = true;
        Pump();
    }

    private void Update()
    {
         ClampPumpPosition();
    }

    //limit the position of the pump
    private void ClampPumpPosition()
    {
        if (transform.position.x != initialPos.x)
        {
           transform.position = new Vector2(initialPos.x, transform.position.y);
        }
        if (transform.position.y < initialPos.y)
        {
            transform.position = new Vector2(transform.position.x, initialPos.y);
        }
        if (transform.position.y >= 3.0f)
        {
           transform.position = new Vector2(transform.position.x, 3.0f);
        }
    }

   
    //read pumping action by user using bool variables to check whether the pump has gone past certain points
    private void Pump()
    {
        //button.onClick.Invoke();
        if (transform.position.y > 1.8f)
        {
            canPump = true;
        }
        if (transform.position.y < 1.6f && canPump)
        {
            isPumped = true;
        }
        if (isPumped && canPump)
        {
            StartCoroutine(PumpCoroutine());
        }
    }

    //wait some seconds before the next pump
    IEnumerator PumpCoroutine()
    {    
        yield return new WaitForSeconds(0.1f);
        canPump = false;
        isPumped = false;
    }

    
    
    }
    
    