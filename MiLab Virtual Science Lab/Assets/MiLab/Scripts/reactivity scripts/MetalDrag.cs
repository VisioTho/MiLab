using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;

    private bool hasCollided = false;

    private void FixedUpdate()
    {

    }
    private void Start()
    {
        initialPos = transform.position;
        hasCollided = false;
    }

    void OnMouseDown()
    {
        //TemperatureReaction.stirTime = 0f;
        Debug.Log("tapped");
        Vibration.Vibrate(60);
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, transform.position.y + 830f, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        transform.gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }

    private void OnMouseUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Collidable")
            transform.position = initialPos;
        if (collision.gameObject.name == "BaseCollider")
            this.hasCollided = true;
        if (collision.gameObject.name == "PetriDish" || collision.gameObject.name == "Metal")
            this.hasCollided = false;

    }

    void Update()
    {

    }
}
