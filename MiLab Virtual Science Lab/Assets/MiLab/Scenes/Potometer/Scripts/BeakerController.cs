using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerController : MonoBehaviour
{
    public bool isConnectedToTube;
    private bool hasExited;

    // register that the beaker has been moved from its position on the potometer
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BeakerArea")
        {
            hasExited = true;
        }
    }

    // register that the beaker has been placed in its position on the potometer

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.name == "BeakerArea")
        {
            if(hasExited)
            {
                isConnectedToTube = true;
                hasExited = false;
            }
        }
    }

    private void Update()
    {
        BubbleController.InitiateBubbleMovement(this);
        Debug.Log("state is " + isConnectedToTube);
    }
}
