using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zincReaction : MonoBehaviour
{
    public static int counter;


    private void Start()
    {
        counter = 0;
    }
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "zinc metal")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
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
