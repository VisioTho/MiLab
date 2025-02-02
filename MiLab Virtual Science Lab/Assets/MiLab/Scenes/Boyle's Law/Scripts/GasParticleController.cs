using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D thisrigidbody2D;
    void Start()
    {
        float f = Random.Range(-100f, 100f);
        thisrigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        thisrigidbody2D.AddForce(new Vector2(f, f), ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if(thisrigidbody2D.linearVelocity.magnitude<0.5f)
        {
            float f = Random.Range(-100f, 100f);
            thisrigidbody2D.AddForce(new Vector2(f, f), ForceMode2D.Force);
        }
        else if(thisrigidbody2D.linearVelocity.magnitude>=1f)
        {
            thisrigidbody2D.linearVelocity.Normalize();
        }
    }
}
