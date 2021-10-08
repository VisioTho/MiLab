using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BobAngleInitializer : MonoBehaviour
{ 
    private bool isBeingHeld;
    private float startPosX, startPosY;
    Vector3 mousepos;
    private void Update()
    {
        if(isBeingHeld)
        {
            GetMousePosition();
            this.gameObject.transform.localPosition = new Vector3(mousepos.x - startPosX, mousepos.y - startPosY, 0);
        }
    }

    private void GetMousePosition()
    {
        mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos); 
    }

    private void OnMouseDown()
    {
        SleepOrWakeBob();

        isBeingHeld = true;
        GetMousePosition();
        startPosX = mousepos.x - this.transform.localPosition.x;
        startPosY = mousepos.y - this.transform.localPosition.y;
    }

    private void SleepOrWakeBob()
    {
        Rigidbody2D bobBody = this.gameObject.GetComponent<Rigidbody2D>();
        if (bobBody.IsSleeping())
        {
            bobBody.WakeUp();
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
