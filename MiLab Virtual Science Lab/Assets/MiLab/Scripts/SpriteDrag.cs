using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;

    private bool hasCollided;

    private void Start()
    {
        initialPos = transform.position;
    }

    void OnMouseDown()
    {
        TemperatureReaction.stirTime = 0f;
        Debug.Log("tapped");
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {
        Debug.Log("dragged");
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Collidable")
            transform.position = initialPos;
        if (collision.gameObject.name == "BaseCollider")
            this.hasCollided = true;
    }

    void Update()
    {
        if (TemperatureReaction.stirTime > 0.6f && this.hasCollided == true)

        {
            Vector2 tempScale = transform.localScale;
            var V = 0.0002f;
            if (tempScale.y > 0.01 && tempScale.x > 0.01)
            {
                tempScale.y -= V;
                tempScale.x -= V;

                transform.localScale = tempScale;
                
            }
            //this.hasCollided = false;
        }
    }
}
