using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massSliderHider : MonoBehaviour
{
    public GameObject massSliderBG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            massSliderBG.SetActive(false);
        }
       
    }
}
