using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodiumHydroxideReaction : ThermometerBehaviour
{
    public static int counter;

    private void Update()
    {
        Debug.Log("counter is " + counter);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.name == "Capsule")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            switch (counter)
            {
                case 0:
                    counter = 1;
                    break;
                case 1:
                    counter = 2;
                    break;
                case 2:
                    counter = 3;
                    break;
                case 3:
                    counter = 4;
                    break;
            }
            TemperatureReaction.stirTime = 0f;
           
        }
    }

}
