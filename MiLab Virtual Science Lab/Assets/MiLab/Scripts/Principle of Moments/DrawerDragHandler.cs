using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerDragHandler : MonoBehaviour
{
    float initialPosX;
    // Start is called before the first frame update
    void Start()
    {
        initialPosX = transform.position.x;
    }

    public void DragOut()
    {
        transform.position = new Vector3(initialPosX - 4f, transform.position.y, transform.position.z);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
    public void DragIn()
    {
        transform.position = new Vector3(initialPosX, transform.position.y, transform.position.z);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
}
