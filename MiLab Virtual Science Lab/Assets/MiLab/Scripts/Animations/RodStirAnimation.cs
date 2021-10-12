using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RodStirAnimation : MonoBehaviour
{
    public void stir()
    {
        gameObject.transform.DOLocalMoveX(8f, 1f, false).
            OnComplete(StirRight) ;
    }

    public void StirRight()
    {
        gameObject.transform.DOLocalMoveX(-8f, 1f, false);
    }
}
