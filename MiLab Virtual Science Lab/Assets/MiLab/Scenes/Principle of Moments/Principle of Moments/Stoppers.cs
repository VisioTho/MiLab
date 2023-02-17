using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stoppers : MassHanger
{
    public GameObject leftStopper, rightStopper;
    Quaternion targetAngle;
    

    public void StopBalancing()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            targetAngle = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, 0);
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * 3f);
        }
    }


}
