using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beaker_visibility_tracker : MonoBehaviour
{
    //whether the folloing beakers are currently visible or not
    public static bool bk1, bk2, bk3, bk4;
    public GameObject custom_substance_toggle;
    // Start is called before the first frame update
    void Start()
    {
        bk1 = true;  
        bk2 = true;  
        bk3 = false;  
        bk4 = true;  
    }
}
