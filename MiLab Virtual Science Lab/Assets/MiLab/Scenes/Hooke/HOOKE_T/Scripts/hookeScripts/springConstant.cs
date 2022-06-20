using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class springConstant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     gameObject.GetComponent<Slider>().value = Random.Range(1,4);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
