using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Capsule")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            switch (TemperatureReaction.pelletsDroppedCounter)
            {
                case 0:
                    TemperatureReaction.pelletsDroppedCounter = 1;
                    break;
                case 1:
                    TemperatureReaction.pelletsDroppedCounter = 2;
                    break;
                case 2:
                    TemperatureReaction.pelletsDroppedCounter = 3;
                    break;
                case 3:
                    TemperatureReaction.pelletsDroppedCounter = 4;
                    break;
            }
            TemperatureReaction.stirTime = 0f;

        }
    }
}
