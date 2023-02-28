using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerController : MonoBehaviour
{
    public bool isConnectedToTube;
    private bool hasExited;
    public GameObject potometer;

    // register that the beaker has been moved from its position on the potometer
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BeakerArea")
        {
            hasExited = true;
            hasCollided = false;
        }
    }

    private void OnMouseDown()
    {
        potometer.LeanMoveLocalY(1.0f, 1.0f);
        isFinishedMoving = false;
    }
    private void OnMouseUp()
    {
        potometer.LeanMoveLocalY(0.47f, 1.0f).setOnComplete(SetPotometerMovementComplete);
    }

    bool isFinishedMoving;
    // register that the beaker has been placed in its position on the potometer
    private void SetPotometerMovementComplete()
    {
        isFinishedMoving = true;
    }
    bool hasCollided;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.name == "BeakerArea")
        {
            hasCollided = true;
        }
    }

    private void Update()
    {
        if(hasCollided)
        {

            if(hasExited)
            {
                if(isFinishedMoving)
                {
                    Debug.Log("apappa");
                    isConnectedToTube = true;
                    hasExited = false;
                }
                
            }
        }
        
        BubbleController.InitiateBubbleMovement(this);
        Debug.Log("is completed" + isFinishedMoving);
        Debug.Log("has collided" + hasCollided);
        Debug.Log("has exited" + hasExited);
    }
}
