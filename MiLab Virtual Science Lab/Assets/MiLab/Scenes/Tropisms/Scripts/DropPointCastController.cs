using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPointCastController : MonoBehaviour
{
    public RaycastHitScriptableObject rayObject;

    RaycastHit2D hit;
    public float distance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 8f);
        if(hit.collider != null)
        {
            Debug.DrawRay(transform.position, hit.point, Color.white);
            rayObject.rayName = hit.collider.name;
            Debug.Log("got a hit" + hit.collider.name);

        }else
        {
            Debug.DrawRay(transform.position, hit.point, Color.blue);
            rayObject.rayName = null;
            Debug.Log("no hi");
        }
    }
}
