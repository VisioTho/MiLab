using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperDrag : MonoBehaviour
{
    public delegate void DragEndedDelegate(DropperDrag draggrableObject);
    public DragEndedDelegate dragEndedCallback;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    float distanceFromCamera;
    public Camera mainCamera;

    private bool hasCollided = false;

    public bool canDrag;

    private void Start()
    {
        canDrag = true;
        initialPos = transform.position;
        hasCollided = false;
        distanceFromCamera = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);
    }

    void OnMouseDown()
    {

        Debug.Log("tapped");
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {
        if (canDrag)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = mainCamera.ScreenToWorldPoint(pos);
            gameObject.GetComponent<Rigidbody2D>().velocity = (pos - transform.position) * 15;
        }



    }

    private void OnMouseUp()
    {
        transform.gameObject.GetComponent<Rigidbody2D>().simulated = true;
       // dragEndedCallback(this);

    }
    void OnTriggerEnter2D(Collider2D col)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }



    void Update()
    {

    }
}
