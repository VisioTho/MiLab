using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class TweenObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Image tweenObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void firstState()
    {
        tweenObject.transform.DORotate(new Vector3(0, 0, 127.5f), 5);
    }

    public void secondState()
    {
        tweenObject.transform.DORotate(new Vector3(0, 0, 0), 5);
    }
}
