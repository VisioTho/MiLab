using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockIntoPosition : MonoBehaviour
{
    public GameObject ruler;
    public GameObject[] masses;
    private Vector3 initialRulerPos;
    private bool locked;
    private void Start()
    {
        initialRulerPos =  ruler.transform.position;
    }

    Quaternion target;
    
    public void LockPosition()
    {
        locked = true;
    }

    public void UnlockPosition()
    {
        locked = false;
    }

    private void Update()
    {
        if (locked)
        {
            target = Quaternion.Euler(ruler.transform.rotation.x, ruler.transform.rotation.y, 0);
            //ruler.transform.rotation 
            ruler.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
            foreach(GameObject i in masses)
            {
                if(i.GetComponent<HingeJoint2D>()!=null)
                    Destroy(i.GetComponent<HingeJoint2D>());
            }
        }
        
    }
}
