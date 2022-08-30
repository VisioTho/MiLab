using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerDrag : MonoBehaviour
{
    float distanceFromCamera;
    public Camera mainCamera;


    private void OnMouseDrag()
    {
        if(gameObject.transform.position.x >= 0.0f)
        {
            Vector3 pos = new Vector3 (0, transform.position.y, transform.position.z);
            pos.z = distanceFromCamera;
            pos = mainCamera.ScreenToWorldPoint(pos);
            gameObject.GetComponent<Rigidbody2D>().velocity = (pos - transform.position) * 15;
        }
    }

    private void OnMouseDown()
    {
       
    }
}
