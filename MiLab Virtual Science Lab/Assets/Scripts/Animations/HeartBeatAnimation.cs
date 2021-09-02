using UnityEngine;
using DG.Tweening;

public class HeartBeatAnimation : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.GetComponent<RectTransform>().DOScale(5f, 1f).SetLoops(-1);
    }

}
