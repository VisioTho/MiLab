using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlideAnimation : MonoBehaviour
{
    Vector2 initialPos;
    public float moveTo;
    private void Start()
    {
        initialPos = gameObject.transform.position;
    }

    public void DoSlideIn()
    {
        SlideIn();
    }
    public void DoSLideOut()
    {
        SlideOut();
    }

    void SlideIn()
    {
        gameObject.transform.LeanMoveLocalY(moveTo, 0.3f);
    }

    void SlideOut()
    {
        gameObject.transform.position = initialPos;
    }
}
