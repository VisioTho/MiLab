using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject droplet, dropPoint;

    public void OnMouseDown()
    {
        Instantiate(droplet, dropPoint.transform.position, Quaternion.identity);
    }
}