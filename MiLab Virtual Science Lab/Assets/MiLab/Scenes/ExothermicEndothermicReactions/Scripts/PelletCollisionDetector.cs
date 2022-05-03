using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.name == "Capsule")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            switch (TemperatureReaction.counter)
            {
                case 0:
                    TemperatureReaction.counter = 1;
                    break;
                case 1:
                    TemperatureReaction.counter = 2;
                    break;
                case 2:
                    TemperatureReaction.counter = 3;
                    break;
                case 3:
                    TemperatureReaction.counter = 4;
                    break;
            }
            TemperatureReaction.stirTime = 0f;

        }
    }
}
