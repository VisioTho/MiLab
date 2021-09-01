using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 0.7f, 1), 0.8f).setEaseLinear().setLoopClamp();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
