using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapController : MonoBehaviour
{
    //public Slider tap;
    public GameObject jetStream;

    public void ControlJetSstream(float val)
    {
        if (val == 0)
            jetStream.SetActive(false);
        else
            jetStream.SetActive(true);

    }
}
