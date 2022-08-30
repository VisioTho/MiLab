using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    float distanceFromCamera;
    public Camera mainCamera;

    private bool hasCollided= false;

    public bool canDrag;
  
    private void Start()
    {
        canDrag = true;
        initialPos = transform.position;
        hasCollided = false;
        distanceFromCamera = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);
    }

    void OnMouseDown()
    {
        
        Debug.Log("tapped");
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {   
        if(canDrag)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = mainCamera.ScreenToWorldPoint(pos);
            gameObject.GetComponent<Rigidbody2D>().velocity = (pos - transform.position) * 15;
        }
        
     

    }

    private void OnMouseUp()
    {
        if(transform.GetChild(0).gameObject != null)
            transform.GetChild(0).gameObject.SetActive(false);

        transform.gameObject.GetComponent<Rigidbody2D>().simulated = true;

       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Collidable")
        {
            transform.LeanMoveLocal(initialPos, 0.5f);
        }
           

        if (collision.gameObject.name == "BaseCollider" && gameObject.name == "Capsule")
        {
            this.hasCollided = true;
        }
            
        if (collision.gameObject.name == "PetriDish" || collision.gameObject.name == "Capsule")
            this.hasCollided = false;
        
    }

   

    void Update()
    {
        if (TemperatureReaction.stirTime > 1.2f && this.hasCollided == true)

        {
            Vector2 tempScale = transform.localScale;
            var V = 0.0002f;
            if (tempScale.y > 0.001 && tempScale.x > 0.001)
            {
                tempScale.y -= V;
                tempScale.x -= V;

                transform.localScale = tempScale;
                
            }
           
        }
        if(transform.localScale.y <=0.001f)
        {
            this.hasCollided = false;
        }

        
    }
}
