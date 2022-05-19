using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronColorChange : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float time = 0;
    public float duration = 8;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void defaultColor()
    {
        if (true)
        {
            // StopCoroutine(changeColors());
            Debug.Log("Coroutine stopped");
            sprite.color = new Color32(255, 255, 255, 255);
        }

    }
    public void ironColorTransition()
    {
        StartCoroutine(ironTransition());
    }

    IEnumerator ironTransition()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(85, 85, 85, 255);

        while (time < duration)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.GetComponent<SpriteRenderer>().color = endColor;
    }

    public void resetTime()
    {
        time = 0;
        StopAllCoroutines();
    }
}
