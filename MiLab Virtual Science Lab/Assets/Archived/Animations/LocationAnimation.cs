﻿using UnityEngine;

public class LocationAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 0.9f, 1), 0.8f).setEaseLinear().setLoopClamp();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
