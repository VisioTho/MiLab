using UnityEngine;

public class BobAngleInitializer : PendulumController
{

    float clampedPosY;
    private Vector3 offset;
    DistanceJoint2D distanceJoint2D;
    float distance;

    private void Start()
    {
        distanceJoint2D = transform.GetComponent<DistanceJoint2D>();
    }
  
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        distance = distanceJoint2D.distance;    
    }
    void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //curPosition.x = Mathf.Clamp(curPosition.x, -3f, 0f);
       // curPosition.y = curPosition.y + 0.1f;
        
        transform.position = curPosition;

    }

    private void Update()
    {
        //Debug.Log("the distance is " +distanceJoint2D.distance +" Y position is " +transform.position.y +"Length slider: " +lengthSlider.value);
        gameObject.GetComponent<DistanceJoint2D>().distance = Mathf.Clamp(gameObject.GetComponent<DistanceJoint2D>().distance, lengthSlider.value, lengthSlider.value);

    }
    /*private Vector3 screenPoint;
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
