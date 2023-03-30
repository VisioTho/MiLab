using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToSpecificPoint : MonoBehaviour
{
    public SnapPoints SnapPoints;
    GameObject[] snapPoints;
    

    public GameObject currentConnectionPoint;

    private Vector2 currentSnapPoint;

    private GameObject nearestTarget; // the nearest target GameObject
    private float nearestDistance = Mathf.Infinity; // the nearest distance found so far

   
   bool hasCollided;

   private void Start() 
   {
        snapPoints = SnapPoints.GetArray();
   }


    private void OnTriggerEnter2D(Collider2D collider) 
    {
        hasCollided =true;
        currentConnectionPoint = collider.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
    }

    void FixedUpdate()
    {
        if(hasCollided)
        {
            for(int i=0; i<snapPoints.Length; i++)
            {
                if(currentConnectionPoint == snapPoints[i])
                {
                    Vector3 newPosition = currentConnectionPoint.transform.position;
                    gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
                }
            }    
            
        }

        if(!hasCollided)
        {
            foreach (GameObject target in snapPoints)
            {
                float distance = Vector2.Distance(transform.position, target.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = target;
                }
            }

            // move the sprite towards the nearest target
            if (nearestTarget != null)
            {
                 Vector3 newPosition = nearestTarget.transform.position;
                gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
            }
        }
        }
        
    }
