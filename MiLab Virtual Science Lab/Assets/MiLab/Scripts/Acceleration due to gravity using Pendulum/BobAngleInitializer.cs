using UnityEngine;

public class BobAngleInitializer : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        Debug.Log("dragged");
    }

    /*
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
            //transform.LeanMoveX(mousepos.x-startPosX, 0.4f); // = new Vector3(mousepos.x - startPosX, mousepos.y - startPosY, 0);
            transform.Translate(Input.mousePosition);
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
    }*/
}
