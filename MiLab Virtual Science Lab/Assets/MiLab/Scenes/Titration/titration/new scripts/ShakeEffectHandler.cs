using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShakeEffectHandler : MonoBehaviour
{
    public bool shouldSnapBack; //set true in the inspector if the object is supposed to snap back to it's original position
    public LiquidControllerScript liquidControllerScript;
    private Vector3 initialposition;
    public float minPosX, maxPosX; //set max and min distance that the object can be dragged in the inspector
    public static bool isShaking;
    public GameObject indicationArrowL, indicationArrowR;
    //  public GameObject iceCubes, sodiumPellets;
    private void Start()
    {
        initialposition = gameObject.transform.position;
    }

    Vector3 offset;
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    private void OnMouseUp()
    {
        indicationArrowL.SetActive(true);
        indicationArrowR.SetActive(true);
    }
    void OnMouseDrag()
    {
        indicationArrowL.SetActive(false);
        indicationArrowR.SetActive(false);
        if (liquidControllerScript.buretteKnob.value == 1 || liquidControllerScript.buretteKnob.value == 2)
        {
            isShaking = true;
        }
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, transform.position.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); //+ offset;
        transform.position = curPosition;
        if (transform.localPosition.x < minPosX)
        {
            //transform.LeanMoveLocalX(-0.2f, 0.5f);
            transform.localPosition = new Vector2(minPosX, transform.localPosition.y);
        }
        else if (transform.localPosition.x > maxPosX)
        {
            transform.localPosition = new Vector2(maxPosX, transform.localPosition.y);
        }
    }

    private void Update()
    {

        if (transform.position.y != initialposition.y)
        {
            transform.position = new Vector3(transform.position.x, initialposition.y, transform.position.z);
        }
    }

    public void OnDrop(PointerEventData eventdata)
    {
        if (shouldSnapBack)
        {
            transform.localPosition = initialposition;
        }
    }
}
