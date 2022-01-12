using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerDragHandler : MonoBehaviour
{
    float initialPosY;
    // Start is called before the first frame update
    void Start()
    {
        initialPosY = transform.position.y;
    }

    public void DragOut()
    {
        transform.position = new Vector3(transform.position.x, initialPosY+3f, transform.position.z);;
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
    public void DragIn()
    {
        transform.position = new Vector3(transform.position.x, initialPosY, transform.position.z);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
    }
}
