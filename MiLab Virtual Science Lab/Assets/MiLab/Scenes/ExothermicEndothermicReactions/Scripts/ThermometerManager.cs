using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerManager : MonoBehaviour
{
    public static bool isImmersed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "beakerliquid")
        {
            Debug.Log("collided");
            isImmersed = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "beakerliquid")
        {
            Debug.Log("exited");
            isImmersed = false;
        }
    }
}
