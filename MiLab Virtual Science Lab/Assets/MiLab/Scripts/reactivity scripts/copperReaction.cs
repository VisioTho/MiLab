using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copperReaction : MonoBehaviour
{
    public static int counter;


    private void Start()
    {
        counter = 0;
    }
    private void Update()
    {
        Debug.Log("counter is " + counter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.name == "copper metal")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
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

        }
    }

}
