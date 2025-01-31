using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

///<summary>
/// Subscribes to the mouse press event on the tree
/// reacts to the event by sending it ot the RotateTree method
/// the rotate tree method gets the new value of mouseOn and behaves accordingly
///</summary>
public class TreeRotationController : MonoBehaviour
{
   
    public TreeRotateScriptableObject treeRotationScriptableObject;

    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private BoxCollider2D col;

    [System.NonSerialized]
    public UnityEvent<int> treeClickedEvent;

    private void Start()
    {
        myCam = Camera.main;
        col = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        treeRotationScriptableObject.treeClickedEvent.AddListener(RotateTree);
    }


    private void Update()
    {
       RotateTree(treeRotationScriptableObject.mouseOn);
       treeRotationScriptableObject.HandleMouseEvent();
    }



  public void RotateTree(int mouseOn)
  {
    
    Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if(col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }

           
        }
        if (Input.GetMouseButton(0))
        {
            if(col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                float clampedAngle = Mathf.Clamp(angle + angleOffset, 2.073f, 76f);
                Quaternion newRotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);
                transform.rotation = newRotation;
                //transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }

  }
}
