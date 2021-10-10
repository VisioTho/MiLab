using DG.Tweening;
using UnityEngine;

public class HeartBeatAnimation : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<RectTransform>().DOScale(1f, 2f).SetLoops(-1);
    }

}
