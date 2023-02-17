using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinMassManager : MonoBehaviour
{
    public GameObject twinMass;
    void Start()
    {

    }

    private void Update()
    {
        if(gameObject.GetComponent<HingeJoint2D>()==null)
        {
            if (twinMass.GetComponent<HingeJoint2D>() == null)
                twinMass.SetActive(true);
        }
    }
}
