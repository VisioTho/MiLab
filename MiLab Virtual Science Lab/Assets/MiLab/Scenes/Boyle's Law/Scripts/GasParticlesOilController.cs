using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasParticlesOilController : MonoBehaviour
{
    public GameObject oil;
   
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(transform.localScale.x, oil.transform.localScale.y-0.2f);
    }
}
