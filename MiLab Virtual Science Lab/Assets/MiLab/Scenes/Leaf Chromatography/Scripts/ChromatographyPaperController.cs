using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromatographyPaperController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.name == "BaseColliderL")
        {
            Debug.Log("Colliding with BaseColliderL");
            transform.position = collision.GetContact(0).point;
        }
    }


}
