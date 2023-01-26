using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOOM_DRAG : MonoBehaviour
{
public GameObject camera;

     private void OnMouseDown()
    {
      camera.GetComponent<ZOOM>().enabled=false;
    }

       private void OnMouseUp()
    {
       camera.GetComponent<ZOOM>().enabled=true;   
    }
}
