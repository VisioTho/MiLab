using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_target : MonoBehaviour
{
 [SerializeField] public GameObject target;
    void OnMouseDrag()
    {
        target.SetActive(true);
        
    }

    void OnMouseUp()
    {
     target.SetActive(false);
    }
}
