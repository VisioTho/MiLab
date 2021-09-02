using UnityEngine;
using DG.Tweening;

public class HeartBeatAnimation : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<RectTransform>().DOScale(10f, 2f).SetLoops(-1);
    }

}
