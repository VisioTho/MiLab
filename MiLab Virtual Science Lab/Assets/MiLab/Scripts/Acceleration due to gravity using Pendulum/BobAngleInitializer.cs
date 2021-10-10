using UnityEngine;

public class BobAngleInitializer : MonoBehaviour
{
    private Vector2 mousepos;
    private Vector2 initialBobPosition;
    private bool isBeingHeld;
    private float startPosX, startPosY;

    private void Start()
    {
        initialBobPosition = transform.position;
    } 

    private void OnMouseDrag()
    {
        if (isBeingHeld)
        {
            transform.localPosition = new Vector3(mousepos.x - startPosX, mousepos.y - startPosY, 0);     
        }
    }
    
    private void GetMousePosition()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   
    }

    private void OnMouseDown()
    {
        WakeBob();
        isBeingHeld = true;
        initialBobPosition = gameObject.transform.localPosition;
        GetMousePosition();
        startPosX = mousepos.x - this.transform.localPosition.x;
        startPosY = mousepos.y - this.transform.localPosition.y;
    }

    private void WakeBob()
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
