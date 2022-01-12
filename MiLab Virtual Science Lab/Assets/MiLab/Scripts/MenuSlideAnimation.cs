using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlideAnimation : MonoBehaviour
{
    Vector2 initialPos;
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
        gameObject.transform.LeanMoveLocalY(0f, 0.3f);
    }

    void SlideOut()
    {
        gameObject.transform.position = initialPos;
    }
}
