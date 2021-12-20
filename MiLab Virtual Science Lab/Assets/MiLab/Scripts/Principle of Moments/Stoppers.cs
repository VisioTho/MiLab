using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stoppers : MassHanger
{
    public GameObject leftStopper, rightStopper;
    Quaternion target;
    

    public void StopBalancing()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            Debug.Log("Its on");
            //massHungL.GetComponent<Rigidbody2D>().mass = 0f;
            //massHungR.GetComponent<Rigidbody2D>().mass = 0f;
            target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, 0);
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
        }
    }


}
