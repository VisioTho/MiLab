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
        //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    void OnMouseDrag()
    {
        
       Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

       Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); //+ offset;
        
       transform.position = curPosition;

        if (transform.position.y > 5f)
            transform.position = new Vector2(transform.position.x, 5f);

    }

    private void OnMouseUp()
    {
        //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update()
    {
        gameObject.GetComponent<DistanceJoint2D>().distance = Mathf.Clamp(gameObject.GetComponent<DistanceJoint2D>().distance, lengthSlider.value, lengthSlider.value);

        
    }
   
}
