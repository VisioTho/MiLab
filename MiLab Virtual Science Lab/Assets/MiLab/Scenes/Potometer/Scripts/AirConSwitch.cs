using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConSwitch : MonoBehaviour
{
    private Vector3 originalRotation;
    private Vector3 rotatedRotation = new Vector3(0, 0, 90);
    private bool isRotated = false;
    private bool isRed = false;
    private Color redColor = Color.red;
    private Color originalColor;
    private SpriteRenderer rend;

    public bool isCoolingRoom;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.eulerAngles;
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
    }

    private void OnMouseDown()
    {
        Debug.Log("habf" + isCoolingRoom);
        if (isRotated)
        {
            transform.eulerAngles = originalRotation;
            isRotated = false;
            rend.color = originalColor;
            isRed = false;
            isCoolingRoom = false;
        }
        else
        {
            transform.eulerAngles = rotatedRotation;
            isRotated = true;
            rend.color = redColor;
            isRed = true;
            isCoolingRoom = true;

        }
    }
 }
   
   

