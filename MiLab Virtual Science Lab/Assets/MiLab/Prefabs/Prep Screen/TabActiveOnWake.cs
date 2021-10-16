using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabActiveOnWake : MonoBehaviour
{
  
    private void Start()
    {
        gameObject.GetComponent<Button>().Select();
    }
}
