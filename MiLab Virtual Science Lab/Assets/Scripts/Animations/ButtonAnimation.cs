using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField]
    private LeanTweenType type;

    public AudioSource tappedSound;

    public void animate()
    {
        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f).setEase(type).setLoopPingPong(1);
        tappedSound.Play();
    }

}
